using Newtonsoft.Json;
using System;
using WebSocketSharp;

namespace API.WebSocket
{
    /// <summary>
    /// Class for transport layer
    /// </summary>
    class Transport
    {
        #region logger

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

        #region private variables

        private readonly string ws_url;
        private WebSocketSharp.WebSocket socket;

        #endregion

        #region events

        public delegate void EventMessage(string mess);

        /// <summary>
        /// Socket open event
        /// </summary>
        public event Action OnSocketOpen;
        /// <summary>
        /// Socket close event
        /// </summary>
        public event EventMessage OnSocketClose;
        /// <summary>
        /// Event on a new message
        /// </summary>
        public event EventMessage OnNewMessage;
        /// <summary>
        /// Error event
        /// </summary>
        public event EventMessage OnSocketError;

        #endregion

        #region constructor/destructor

        public Transport(string url)
        {
            ws_url = url ?? throw new ArgumentNullException("url");
        }

        ~Transport()
        {
            Clear();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create socket
        /// </summary>
        public void Create()
        {
            logger.Trace(ws_url);

            try
            {
                socket = new WebSocketSharp.WebSocket(ws_url);

                socket.OnOpen += Socket_OnOpen;
                socket.OnClose += Socket_OnClose;
                socket.OnError += Socket_OnError;
                socket.OnMessage += Socket_OnMessage;

                socket.Connect();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "WebSocket Create Exception");
            }
        }

        /// <summary>
        /// Close socket
        /// </summary>
        public void Clear()
        {
            logger.Trace("");

            if (socket == null) return;

            try
            {
                if (socket.ReadyState == WebSocketState.Open)
                {
                    socket.Close();
                }

                socket.OnOpen -= Socket_OnOpen;
                socket.OnClose -= Socket_OnClose;
                socket.OnError -= Socket_OnError;
                socket.OnMessage -= Socket_OnMessage;

                socket = null;
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "WebSocket Clear Exception");
            }
        }

        /// <summary>
        /// Send mess to socket
        /// </summary>
        public void Send(string mess)
        {
            if (socket == null)
            {
                logger.Error("Socket not connect");

                return;
            }

            try
            {
                socket.Send(mess);
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
        private void Socket_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                OnNewMessage?.Invoke(e.Data);

                // unzip data
                //if (e.IsBinary)
                //    OnNewMessage?.Invoke(unzip(e.RawData));
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Websocket OnMessage Exception");
            }
        }

        /// <summary>
        /// Event handler for opening socket
        /// </summary>
        private void Socket_OnOpen(object sender, EventArgs e)
        {
            logger.Trace("{0}", JsonConvert.SerializeObject(e));

            OnSocketOpen?.Invoke();
        }

        /// <summary>
        /// Event handler for closing a socket
        /// </summary>
        private void Socket_OnClose(object sender, CloseEventArgs e)
        {
            logger.Trace("{0}", JsonConvert.SerializeObject(e));

            OnSocketClose?.Invoke(e.Reason);
        }

        /// <summary>
        /// Event handler for socket error
        /// </summary>
        private void Socket_OnError(object sender, ErrorEventArgs e)
        {
            logger.Trace("{0}", JsonConvert.SerializeObject(e));

            OnSocketError?.Invoke(e.Message);
        }

        #endregion
    }
}
