using API.Enums;
using API.Model;
using API.Utils;
using API.WebSocket;
using API.WebSocket.Enums;
using API.WebSocket.Model.Blocks;
using API.WebSocket.Model.Blocks.Values;
using API.WebSocket.Model.Get;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TestForm
{
    public partial class UserAPI : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private WebSocket socket;

        private ValuePairs pairs;
        private ValueBoxState box_state;
        private ValueBalances balance = new ValueBalances();
        private Dictionary<string, ValueOrders> orders = new Dictionary<string, ValueOrders>();
        private Dictionary<string, ValueDeals> deals = new Dictionary<string, ValueDeals>();

        private bool smart_subs = false;

        public UserAPI(WebSocket socket)
        {
            InitializeComponent();

            this.socket = socket;
        }

        private void UserAPI_Load(object sender, EventArgs e)
        {
            if (socket != null)
            {
                socket.OnDataPairs += Socket_OnDataPairs;
                socket.OnDataBoxState += Socket_OnDataBoxState;
                socket.OnDataBalances += Socket_OnDataBalances;
                socket.OnDataBalance += Socket_OnDataBalance;
                socket.OnDataOrders += Socket_OnDataOrders;
                socket.OnDataDeals += Socket_OnDataDeals;
                socket.OnDataMessages += Socket_OnDataMessages;

                // get market data
                socket?.Send(Subs.Pairs(SubsType.GetExist));

                // get user keys info
                socket?.Send(Subs.BoxState(SubsType.GetExist));
            }
        }

        private void UserAPI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (socket != null)
            {
                socket.OnDataPairs -= Socket_OnDataPairs;
                socket.OnDataBoxState -= Socket_OnDataBoxState;
                socket.OnDataBalances -= Socket_OnDataBalances;
                socket.OnDataBalance -= Socket_OnDataBalance;
                socket.OnDataOrders -= Socket_OnDataOrders;
                socket.OnDataDeals -= Socket_OnDataDeals;
                socket.OnDataMessages -= Socket_OnDataMessages;
            }

            socket?.Send(Subs.UnsubsAll());
        }

        private MarketType GetMarket()
        {
            if (lbMarkets.SelectedItem == null)
            {
                MessageBox.Show("No Markets selected", "Warning");
                return MarketType.Empty;
            }

            string market = lbMarkets.SelectedItem.ToString();
            market = market.Replace(SKey.demo, string.Empty);
            return EnumValue.GetEnum<MarketType>(market);
        }

        private void SendSubs_Click(object sender, EventArgs e)
        {
            if (clbName.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Subs Name checked", "Warning");
                return;
            }
            if (clbType.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Subs Type checked", "Warning");
                return;
            }

            MarketType market;

            foreach (var proc in clbName.CheckedItems)
            {
                foreach (var type in clbType.CheckedItems)
                {
                    var subs_type = SubsType.GetExist;
                    switch (type.ToString())
                    {
                        case "Only get":
                            subs_type = SubsType.GetExist;
                            break;
                        case "Subscribe and get":
                            subs_type = SubsType.SubsAndGetExist;
                            break;
                        case "Subscribe and get next":
                            subs_type = SubsType.SubsAndGetNextChange;
                            break;
                        case "Unsubscribe":
                            subs_type = SubsType.UnSubs;
                            break;
                        case "Unsubscribe and get":
                            subs_type = SubsType.UnSubsAndGetExist;
                            break;
                        default:
                            subs_type = SubsType.GetExist;
                            break;
                    }

                    string mess = null;
                    switch (proc.ToString())
                    {
                        case "User keys":
                            if (!rbReal.Checked)
                            {
                                MessageBox.Show("User keys only for Real", "Warning");
                                return;
                            }
                            mess = Subs.BoxState(subs_type);
                            break;
                        case "Balances":
                            mess = Subs.Balances(subs_type, rbReal.Checked ? SysType.Real : SysType.Demo);
                            break;
                        case "Market balance":
                            if (!rbReal.Checked)
                            {
                                MessageBox.Show("Market balance only for Real", "Warning");
                                return;
                            }
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            mess = Subs.Balance(subs_type, market);
                            break;
                        case "Orders":
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            mess = Subs.Orders(subs_type, market, rbReal.Checked ? SysType.Real : SysType.Demo);
                            break;
                        case "Deals":
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            mess = Subs.Deals(subs_type, market, rbReal.Checked ? SysType.Real : SysType.Demo);
                            break;
                        case "Messages":
                            mess = Subs.Messages(subs_type);
                            break;
                        default:
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(mess)) socket?.Send(mess);
                }
            }
        }

        private void UnsubsAll_Click(object sender, EventArgs e)
        {
            socket.Send(Subs.UnsubsAll());
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            lbKeysTime.Text = string.Empty;
            lbBalance.Text = string.Empty;
            lbOrders.Text = string.Empty;
            lbDeals.Text = string.Empty;
            lbMessages.Text = string.Empty;

            lbMarkets.Items.Clear();
            chkBad.Checked = false;
            tbKeyError.Text = string.Empty;
            lbMarketSelect.Text = "no market selected";

            dgBalanceAvailable.DataSource = null;
            dgBalanceTotal.DataSource = null;
            dgOrders.DataSource = null;
            dgDeals.DataSource = null;
            dgMessages.DataSource = null;
        }

        private void Smart_Click(object sender, EventArgs e)
        {
            socket?.Send(Subs.Messages(SubsType.SubsAndGetExist));

            if (rbReal.Checked)
            {
                socket?.Send(Subs.BoxState(SubsType.SubsAndGetExist));
                socket?.Send(Subs.Balances(SubsType.SubsAndGetExist, SysType.Real));
            }
            else
            {
                socket?.Send(Subs.Balances(SubsType.SubsAndGetExist, SysType.Demo));
            }

            smart_subs = true;
        }

        private void Place_Click(object sender, EventArgs e)
        {
            if (lbMarkets.SelectedItem == null)
            {
                MessageBox.Show("No Markets selected", "Warning");
                return;
            }

            var market = GetMarket();
            if (market == MarketType.Empty) return;

            using (var form = new OrderPlace(
                market,
                pairs.Data[EnumValue.GetValue(market)]))
            {
                form.ShowDialog();
                if (form.IsOK)
                {
                    socket?.Send(Sends.OrderPlace(
                        rbReal.Checked ? SysType.Real : SysType.Demo,
                        market, 
                        new Order {
                            Pair = form.cbPair.Text,
                            Side = form.rbBuy.Checked ? OrderSide.Buy : OrderSide.Sell,
                            Type = form.rbLimit.Checked ? OrderType.Limit : OrderType.Market,
                            Amount = form.tbAmount.Text,
                            Price = form.rbLimit.Checked ? form.tbPrice.Text : null,
                        },
                        string.IsNullOrWhiteSpace(form.tbGUID.Text) ? null : form.tbGUID.Text
                    ));
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (dgOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("No order selected", "Warning");
                return;
            }

            var market = GetMarket();
            if (market == MarketType.Empty) return;

            foreach (DataGridViewRow row in dgOrders.SelectedRows)
            {
                socket?.Send(Sends.OrderCancel(
                    rbReal.Checked ? SysType.Real : SysType.Demo,
                    market,
                    new Order {
                        OrderID = row.Cells["OrderID"].Value.ToString()
                    }
                ));
            }
        }

        private void Move_Click(object sender, EventArgs e)
        {
            if (dgOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("No order selected", "Warning");
                return;
            }

            var market = GetMarket();
            if (market == MarketType.Empty) return;

            foreach (DataGridViewRow row in dgOrders.SelectedRows)
            {
                using (var form = new OrderPlace(
                    market,
                    pairs.Data[EnumValue.GetValue(market)],
                    new {
                        pair = row.Cells["Pair"].Value?.ToString(),
                        buy = row.Cells["Side"].Value?.ToString() == "Buy",
                        limit = row.Cells["Type"].Value?.ToString() == "Limit",
                        amount = row.Cells["Amount"].Value?.ToString(),
                        price = row.Cells["Price"].Value?.ToString(),
                        guid = row.Cells["API_GUID"].Value?.ToString()
                    }))
                {
                    form.ShowDialog();
                    if (form.IsOK)
                    {
                        socket?.Send(Sends.OrderMove(
                            rbReal.Checked ? SysType.Real : SysType.Demo,
                            market,
                            new Order {
                                OrderID = row.Cells["OrderID"].Value.ToString(),
                                Price = form.tbPrice.Text
                            }
                        ));
                    }
                }
            }
        }

        private void GetBalance_Click(object sender, EventArgs e)
        {
            if (!rbReal.Checked)
            {
                MessageBox.Show("Get balance only for Real", "Warning");
                return;
            }

            var market = GetMarket();
            if (market == MarketType.Empty) return;
            socket?.Send(Sends.GetBalance(market));
        }

        private void Type_CheckedChanged(object sender, EventArgs e)
        {
            UnsubsAll_Click(sender, e);
            Clear_Click(sender, e);

            if (rbReal.Checked)
            {
                // get user keys info
                socket?.Send(Subs.BoxState(SubsType.GetExist));
            }
            else if (rbDemo.Checked)
            {
                // get a list of demo markets
                socket?.Send(Subs.Balances(SubsType.SubsAndGetExist, SysType.Demo));
            }
        }

        private void Markets_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbMarkets.SelectedItem == null) return;

            lbMarketSelect.Text = "market: " + lbMarkets.SelectedItem.ToString();

            if (rbReal.Checked)
            {
                if (box_state.Box.TryGetValue(lbMarkets.SelectedItem.ToString(), out MarketKeys keys))
                {
                    var key = keys.Keys.First();

                    chkBad.Checked = key.BadKey;
                    tbKeyError.Text = key.Message;
                }
            }

            UpdateBalances();
            UpdateOrders();
            UpdateDeals();
        }

        private void Socket_OnDataPairs(MessGet data)
        {
            // save
            pairs = (data as MessGetPairs)?.Value;
        }

        private void Socket_OnDataBoxState(MessGet data)
        {
            // save
            box_state = (data as MessGetBoxState)?.Value;

            var markets = (data as MessGetBoxState)?.Value?.Box?
                        .Where(x => x.Value.Keys.Exists(y => y.Disable == false))
                        .Select(x => x.Key);


            UpdateMarkets(markets.ToList());
        }

        private void UpdateMarkets(List<string> markets)
        {
            // subs to all markets
            if (smart_subs)
            {
                smart_subs = false;
                foreach (var item in markets)
                {
                    var market = EnumValue.GetEnum<MarketType>(item.Replace(SKey.demo, string.Empty));

                    if (rbReal.Checked) socket?.Send(Subs.Balance(SubsType.SubsAndGetNextChange, market));
                    socket?.Send(Subs.Orders(SubsType.SubsAndGetExist, market, rbReal.Checked ? SysType.Real : SysType.Demo));
                    socket?.Send(Subs.Deals(SubsType.SubsAndGetExist, market, rbReal.Checked ? SysType.Real : SysType.Demo));
                }
            }

            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbKeysTime.Text = DateTime.Now.ToString();

                    // load markets
                    lbMarkets.Items.Clear();
                    lbMarkets.Items.AddRange(markets.ToArray());
                }));
            }
            catch { }
        }

        private void Socket_OnDataBalance(MessGet data)
        {
            // save
            balance.Balances = balance?.Balances ?? new Dictionary<string, BalancesData>();
            balance.Balances[(data as MessGetBalance)?.Key.MarketName] = (data as MessGetBalance)?.Value;

            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbBalance.Text = "Update time: " + DateTime.Now.ToString() + " for market " + (data as MessGetBalance)?.Key.MarketName;
                }));
            }
            catch { }

            UpdateBalances();
        }

        private void Socket_OnDataBalances(MessGet data)
        {
            // save
            balance = (data as MessGetBalances)?.Value;

            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbBalance.Text = "Update time: " + DateTime.Now.ToString();
                }));
            }
            catch { }

            if ((data as MessGetBalances)?.Key.SysType == SysType.Demo)
            {
                UpdateMarkets(balance?.Balances?.Keys.ToList());
            }

            UpdateBalances();
        }

        private void UpdateBalances()
        {
            if ((balance == null) || (balance.Balances == null)) return;

            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    dgBalanceAvailable.DataSource = null;
                    dgBalanceTotal.DataSource = null;

                    if (lbMarkets.SelectedItem == null) return;

                    if (balance.Balances.TryGetValue(lbMarkets.SelectedItem?.ToString(), out BalancesData value))
                    {
                        dgBalanceAvailable.AutoGenerateColumns = true;
                        dgBalanceAvailable.DataSource = value.Available?.ToList();
                        dgBalanceTotal.AutoGenerateColumns = true;
                        dgBalanceTotal.DataSource = value.Total?.ToList();
                    }
                }));
            }
            catch { }
        }

        private void Socket_OnDataOrders(MessGet data)
        {
            // save
            orders[(data as MessGetOrders)?.Key.MarketName] = (data as MessGetOrders)?.Value;

            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbOrders.Text = "Update time: " + DateTime.Now.ToString() + " for market " + (data as MessGetOrders)?.Key.MarketName;
                }));
            }
            catch { }

            UpdateOrders();
        }

        private void UpdateOrders()
        {
            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    dgOrders.DataSource = null;

                    if (lbMarkets.SelectedItem == null) return;

                    if (orders.TryGetValue(lbMarkets.SelectedItem?.ToString(), out ValueOrders value))
                    {
                        dgOrders.AutoGenerateColumns = true;
                        dgOrders.DataSource = value.Orders?.ToList();
                    }
                }));
            }
            catch { }
        }

        private void Socket_OnDataDeals(MessGet data)
        {
            // save
            deals[(data as MessGetDeals)?.Key.MarketName] = (data as MessGetDeals)?.Value;

            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbDeals.Text = "Update time: " + DateTime.Now.ToString() + " for market " + (data as MessGetDeals)?.Key.MarketName;
                }));
            }
            catch { }

            UpdateDeals();
        }

        private void UpdateDeals()
        {
            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    dgDeals.DataSource = null;

                    if (lbMarkets.SelectedItem == null) return;

                    if (deals.TryGetValue(lbMarkets.SelectedItem?.ToString(), out ValueDeals value))
                    {
                        dgDeals.AutoGenerateColumns = true;
                        dgDeals.DataSource = value.Orders?.ToList();
                    }
                }));
            }
            catch { }
        }

        private void Socket_OnDataMessages(MessGet data)
        {
            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbMessages.Text = "Update time: " + DateTime.Now.ToString();

                    dgMessages.DataSource = null;
                    dgMessages.AutoGenerateColumns = true;
                    dgMessages.DataSource = (data as MessGetMessages)?.Value;
                }));
            }
            catch { }
        }
    }
}
