using API.WebSocket.Enums;
using API.WebSocket.Model.Get;
using Newtonsoft.Json;
using System;

namespace API.WebSocket
{
    public class WebSocket
    {
        #region logger

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

        #region private variables

        private const string DefaultUrl = @"wss://bitsgap.com/ws/?wsguid=";
        private const int LogMessSize = 500;

        private readonly string ws_url;
        private readonly string public_key;
        private readonly string private_key;

        private Transport transport;

        #endregion

        #region events

        public delegate void EventMessage(string mess);
        public event Action OnSocketOpen;
        public event EventMessage OnSocketClose;
        public event EventMessage OnNewMessage;
        public event EventMessage OnSocketError;
        public event Action OnAuthRequest;
        public event Action OnAuthSuccess;
        public event Action OnAuthFail;

        public delegate void EventData(MessGet data);
        public event EventData OnDataPairs;
        public event EventData OnDataPairsDetail;
        public event EventData OnDataOrderbook;
        public event EventData OnDataRecentTrades;
        public event EventData OnDataLastPrice;
        public event EventData OnDataPriceByTime;
        public event EventData OnDataBoxState;
        public event EventData OnDataBalances;
        public event EventData OnDataBalance;
        public event EventData OnDataOrders;
        public event EventData OnDataDeals;
        public event EventData OnDataMessages;

        #endregion

        #region constructor/destructor

        public WebSocket(string public_key, string private_key, string url = null)
        {
            ws_url = url ?? DefaultUrl;
            this.public_key = public_key ?? throw new ArgumentNullException("public_key");
            this.private_key = private_key ?? throw new ArgumentNullException("private_key");
        }

        ~WebSocket()
        {
            Stop();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create socket
        /// </summary>
        public void Start()
        {
            logger.Trace("");

            try
            {
                if (transport != null)
                {
                    Stop();
                }

                transport = new Transport(ws_url + public_key);
                transport.OnSocketOpen += Transport_OnSocketOpen;
                transport.OnSocketClose += Transport_OnSocketClose;
                transport.OnSocketError += Transport_OnSocketError;
                transport.OnNewMessage += Transport_OnNewMessage;
                transport.Create();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "WebSocket Start Exception");
            }
        }

        /// <summary>
        /// Close socket
        /// </summary>
        public void Stop()
        {
            logger.Trace("");

            try
            {
                if (transport != null)
                {
                    transport.Clear();
                    transport.OnSocketOpen -= Transport_OnSocketOpen;
                    transport.OnSocketClose -= Transport_OnSocketClose;
                    transport.OnSocketError -= Transport_OnSocketError;
                    transport.OnNewMessage -= Transport_OnNewMessage;
                    transport = null;
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "WebSocket Stop Exception");
            }
        }

        /// <summary>
        /// Send mess to socket
        /// </summary>
        public void Send(string mess)
        {
            logger.Debug(mess);

            try
            {
                if (transport != null)
                {
                    transport.Send(mess);
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "WebSocket Send Exception");
            }
        }

        #endregion

        #region event handlers

        /// <summary>
        /// Event handler to get new message from socket
        /// </summary>
        private void Transport_OnNewMessage(string mess)
        {
            try
            {
                OnNewMessage?.Invoke(mess);

                // check authorization
                var request_auth = new MessGetAuthorization();
                if (request_auth.Parse(mess))
                {
                    logger.Debug(mess);

                    if (request_auth.IsNeedAuthorize)
                    {
                        logger.Debug("This is authorization request");

                        OnAuthRequest?.Invoke();

                        request_auth.GenerateResponse(public_key, private_key);
                        Send(JsonConvert.SerializeObject(request_auth));
                    }
                    else
                    {
                        if (request_auth.IsAuthorizeOk)
                        {
                            logger.Info("Authorization successful");
                            OnAuthSuccess?.Invoke();
                        }
                        else
                        {
                            logger.Error("Authorization is invalid");
                            OnAuthFail?.Invoke();
                        }
                    }

                    return;
                }

                logger.Debug(mess.Length > LogMessSize ? mess.Substring(1, LogMessSize) + "..." : mess);

                // parse result
                var request = JsonConvert.DeserializeObject<MessGet>(mess);
                switch (request.Key.Proc)
                {
                    case ProcType.Pairs:
                        OnDataPairs?.Invoke(JsonConvert.DeserializeObject<MessGetPairs>(mess));
                        break;
                    case ProcType.PairsDetail:
                        OnDataPairsDetail?.Invoke(JsonConvert.DeserializeObject<MessGetPairsDetail>(mess));
                        break;
                    case ProcType.Orderbook:
                        OnDataOrderbook?.Invoke(JsonConvert.DeserializeObject<MessGetOrderbook>(mess));
                        break;
                    case ProcType.RecentTrades:
                        OnDataRecentTrades?.Invoke(JsonConvert.DeserializeObject<MessGetRecentTrades>(mess));
                        break;
                    case ProcType.LastPrice:
                        OnDataLastPrice?.Invoke(JsonConvert.DeserializeObject<MessGetLastPrice>(mess));
                        break;
                    case ProcType.PriceDay:
                    case ProcType.PriceWeek:
                    case ProcType.PriceMonth:
                        OnDataPriceByTime?.Invoke(JsonConvert.DeserializeObject<MessGetPriceByTime>(mess));
                        break;
                    case ProcType.BoxState:
                        OnDataBoxState?.Invoke(JsonConvert.DeserializeObject<MessGetBoxState>(mess));
                        break;
                    case ProcType.Balances:
                        OnDataBalances?.Invoke(JsonConvert.DeserializeObject<MessGetBalances>(mess));
                        break;
                    case ProcType.Balance:
                        OnDataBalance?.Invoke(JsonConvert.DeserializeObject<MessGetBalance>(mess));
                        break;
                    case ProcType.Orders:
                        OnDataOrders?.Invoke(JsonConvert.DeserializeObject<MessGetOrders>(mess));
                        break;
                    case ProcType.Deals:
                        OnDataDeals?.Invoke(JsonConvert.DeserializeObject<MessGetDeals>(mess));
                        break;
                    case ProcType.Messages:
                        OnDataMessages?.Invoke(JsonConvert.DeserializeObject<MessGetMessages>(mess));
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Exception parse new message");
            }
        }

        /// <summary>
        /// Event handler for opening socket
        /// </summary>
        private void Transport_OnSocketOpen()
        {
            OnSocketOpen?.Invoke();
        }

        /// <summary>
        /// Event handler for closing a socket
        /// </summary>
        private void Transport_OnSocketClose(string mess)
        {
            OnSocketClose?.Invoke(mess);
        }

        /// <summary>
        /// Event handler for socket error
        /// </summary>
        private void Transport_OnSocketError(string mess)
        {
            OnSocketError?.Invoke(mess);
        }

        #endregion
    }
}
