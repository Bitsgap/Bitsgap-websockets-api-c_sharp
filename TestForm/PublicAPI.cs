using API.Utils;
using API.Enums;
using API.WebSocket;
using API.WebSocket.Enums;
using API.WebSocket.Model.Blocks.Values;
using API.WebSocket.Model.Get;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TestForm
{
    public partial class PublicAPI : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private WebSocket socket;

        private ValuePairs pairs;

        public PublicAPI(WebSocket socket)
        {
            InitializeComponent();

            this.socket = socket;
        }

        private void PublicAPI_Load(object sender, EventArgs e)
        {
            if (socket != null)
            {
                socket.OnDataPairs += Socket_OnDataPairs;
                socket.OnDataPairsDetail += Socket_OnDataPairsDetail;
                socket.OnDataOrderbook += Socket_OnDataOrderbook;
                socket.OnDataRecentTrades += Socket_OnDataRecentTrades;
                socket.OnDataLastPrice += Socket_OnDataLastPrice;
                socket.OnDataPriceByTime += Socket_OnDataPriceByTime;

                // get market data
                socket?.Send(Subs.Pairs(SubsType.GetExist));
            }
        }

        private void PublicAPI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (socket != null)
            {
                socket.OnDataPairs -= Socket_OnDataPairs;
                socket.OnDataPairsDetail -= Socket_OnDataPairsDetail;
                socket.OnDataOrderbook -= Socket_OnDataOrderbook;
                socket.OnDataRecentTrades -= Socket_OnDataRecentTrades;
                socket.OnDataLastPrice -= Socket_OnDataLastPrice;
                socket.OnDataPriceByTime -= Socket_OnDataPriceByTime;
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
            return EnumValue.GetEnum<MarketType>(lbMarkets.SelectedItem.ToString());
        }

        private string GetPair()
        {
            if (lbPairs.SelectedItem == null)
            {
                MessageBox.Show("No Pairs selected", "Warning");
                return null;
            }

            return lbPairs.SelectedItem.ToString();
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
            string pair;

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
                        case "Market and Pairs" :
                            mess = Subs.Pairs(subs_type);
                            break;
                        case "Pairs configuration" :
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            mess = Subs.PairsDetail(subs_type, market);
                            break;
                        case "Orderbook" :
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            pair = GetPair();
                            if (pair == null) return;
                            mess = Subs.Orderbook(subs_type, market, pair);
                            break;
                        case "Recent trades" :
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            pair = GetPair();
                            if (pair == null) return;
                            mess = Subs.RecentTrades(subs_type, market, pair);
                            break;
                        case "Last price" :
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            pair = GetPair();
                            if (pair == null) return;
                            mess = Subs.LastPrice(subs_type, market, pair);
                            break;
                        case "Historical price":
                            market = GetMarket();
                            if (market == MarketType.Empty) return;
                            pair = GetPair();
                            if (pair == null) return;
                            if (rbDay.Checked)
                            {
                                mess = Subs.PriceDay(subs_type, market, pair);
                            }
                            else if (rbWeek.Checked)
                            {
                                mess = Subs.PriceWeek(subs_type, market, pair);
                            }
                            else if (rbMonth.Checked)
                            {
                                mess = Subs.PriceMonth(subs_type, market, pair);
                            }

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
            tabData.TabPages.Clear();
        }

        private void Markets_SelectedValueChanged(object sender, EventArgs e)
        {
            // load pairs
            lbPairs.Items.Clear();
            lbPairs.Items.AddRange(pairs.Data[lbMarkets.SelectedItem.ToString()].ToArray());
        }

        private TabPage FindOrAddTab(string name)
        {
            foreach (var item in tabData.TabPages)
            {
                if ((item as TabPage).Text == name)
                    return item as TabPage;
            }

            var page = new TabPage(name);
            try
            {
                this.BeginInvoke((Action)(() => {
                    tabData.TabPages.Add(page);
                }));
            }
            catch { }

            return page;
        }

        private RichTextBox FindOrAddControl(string name, Control parent)
        {
            var controls = this.Controls.Find(name, true);
            RichTextBox text_box;
            if (controls.Count() == 0)
            {
                text_box = new RichTextBox
                {
                    Name = name,
                };

                try
                {
                    this.BeginInvoke((Action)(() => {
                        text_box.Parent = parent;
                        text_box.Dock = DockStyle.Fill;
                    }));
                }
                catch { }
            }
            else
            {
                text_box = controls.First() as RichTextBox;
            }

            return text_box;
        }

        private void Socket_OnDataPairs(MessGet data)
        {
            // save
            pairs = (data as MessGetPairs)?.Value;

            // load markets
            try
            {
                this.BeginInvoke((Action)(() => {
                    lbMarkets.Items.Clear();
                    lbMarkets.Items.AddRange(pairs.Data.Keys.ToArray());
                }));
            }
            catch { }
        }

        private void Socket_OnDataPairsDetail(MessGet data)
        {
            var market = (data as MessGetPairsDetail)?.Key?.MarketName;
            var pairs_detail = (data as MessGetPairsDetail)?.Value;

            // exists or new tab
            var page_name = market + " Pairs configuration";
            var page = FindOrAddTab(page_name);

            market = EnumValue.GetEnum<MarketType>(market).ToString();
            var text_box_name = "rtb" + market + "Pairs_configuration";
            RichTextBox text_box = FindOrAddControl(text_box_name, page);
            try
            {
                this.BeginInvoke((Action)(() => {
                    text_box.Clear();
                    text_box.Text += "Update time: " + DateTime.Now.ToString() + "\n";

                    foreach (var item in pairs_detail)
                    {
                        text_box.Text += JsonConvert.SerializeObject(item) + "\n";
                    }
                }));
            }
            catch { }
        }

        private void Socket_OnDataOrderbook(MessGet data)
        {
            var market = (data as MessGetOrderbook)?.Key?.MarketName;
            var pair = (data as MessGetOrderbook)?.Key?.Pair;
            var orderbook = (data as MessGetOrderbook)?.Value;

            // exists or new tab
            var page_name = market + " " + pair + " Orderbook";
            var page = FindOrAddTab(page_name);

            market = EnumValue.GetEnum<MarketType>(market).ToString();
            var text_box_name = "rtb" + market + pair + "Orderbook";
            RichTextBox text_box = FindOrAddControl(text_box_name, page);
            try
            {
                this.BeginInvoke((Action)(() => {
                    text_box.Clear();
                    text_box.Text += "Update time: " + DateTime.Now.ToString() + "\n";

                    if (orderbook?.ASKs == null)
                    {
                        text_box.Text += "ASKs: NULL\n";
                    }
                    else
                    {
                        text_box.Text += "ASKs:\n";
                        foreach (var item in orderbook.ASKs)
                        {
                            text_box.Text += "price=" + item.Key + ", amount=" + item.Value + "\n";
                        }
                    }
                    if (orderbook?.BIDs == null)
                    {
                        text_box.Text += "BIDs: NULL\n";
                    }
                    else
                    {
                        text_box.Text += "BIDs:\n";
                        foreach (var item in orderbook.BIDs)
                        {
                            text_box.Text += "price=" + item.Key + ", amount=" + item.Value + "\n";
                        }
                    }
                }));
            }
            catch { }
        }

        private void Socket_OnDataRecentTrades(MessGet data)
        {
            var market = (data as MessGetRecentTrades)?.Key?.MarketName;
            var pair = (data as MessGetRecentTrades)?.Key?.Pair;
            var recent_trades = (data as MessGetRecentTrades)?.Value;

            // exists or new tab
            var page_name = market + " " + pair + " Recent trades";
            var page = FindOrAddTab(page_name);

            market = EnumValue.GetEnum<MarketType>(market).ToString();
            var text_box_name = "rtb" + market + pair + "Recent_trades";
            RichTextBox text_box = FindOrAddControl(text_box_name, page);
            try
            {
                this.BeginInvoke((Action)(() => {
                    text_box.Clear();
                    text_box.Text += "Update time: " + DateTime.Now.ToString() + "\n";

                    foreach (var item in recent_trades)
                    {
                        text_box.Text += JsonConvert.SerializeObject(item) + "\n";
                    }
                }));
            }
            catch { }
        }

        private void Socket_OnDataLastPrice(MessGet data)
        {
            var market = (data as MessGetLastPrice)?.Key?.MarketName;
            var pair = (data as MessGetLastPrice)?.Key?.Pair;
            var last_price = new ValueLastPrice
            {
                Data = (data as MessGetLastPrice)?.Value
            };

            // exists or new tab
            var page_name = market + " " + pair + " Last price";
            var page = FindOrAddTab(page_name);

            market = EnumValue.GetEnum<MarketType>(market).ToString();
            var text_box_name = "rtb" + market + pair + "Last_price";
            RichTextBox text_box = FindOrAddControl(text_box_name, page);
            try
            {
                this.BeginInvoke((Action)(() => {
                    text_box.Clear();
                    text_box.Text += "Update time: " + DateTime.Now.ToString() + "\n";
                    text_box.Text += JsonConvert.SerializeObject(last_price) + "\n";
                }));
            }
            catch { }
        }

        private void Socket_OnDataPriceByTime(MessGet data)
        {
            var market = (data as MessGetPriceByTime)?.Key?.MarketName;
            var pair = (data as MessGetPriceByTime)?.Key?.Pair;
            var price = (data as MessGetPriceByTime)?.Value?.Price;

            // exists or new tab
            var page_name = market + " " + pair + " Historical price";
            var page = FindOrAddTab(page_name);

            market = EnumValue.GetEnum<MarketType>(market).ToString();
            var text_box_name = "rtb" + market + pair + "Historical_price";
            RichTextBox text_box = FindOrAddControl(text_box_name, page);
            try
            {
                this.BeginInvoke((Action)(() => {
                    text_box.Text += "Update time: " + DateTime.Now.ToString() + " " +
                    EnumValue.GetValue((data as MessGetPriceByTime).Key.Proc) + " " +
                    price + "\n";
                }));
            }
            catch { }
        }
    }
}
