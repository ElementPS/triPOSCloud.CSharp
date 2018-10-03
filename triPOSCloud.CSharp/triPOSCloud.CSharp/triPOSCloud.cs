using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Dynamic;
using Newtonsoft.Json;


namespace triPOSCloud.CSharp
{
    public partial class triPOSCloud : Form
    {
        public triPOSCloud()
        {
            InitializeComponent();
        }

        private void btnDeleteLane_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/cloudapi/v1/lanes/1";
                var webRequest = new HttpSender();
                var response = webRequest.Send(string.Empty, url, "json", "DELETE", GetHeaders());
                txtResponse.Text = response;
            } catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void btnPairLane_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/cloudapi/v1/lanes/";

                var activationCodeDialog = new ActivationCodeInput();
                var activationCode = string.Empty;

                if (activationCodeDialog.ShowDialog(this) == DialogResult.OK)
                {
                    activationCode = activationCodeDialog.ActivationCode;
                }

                activationCodeDialog.Dispose();

                string data = @"{""laneId"": 1,""description"": ""triPOSCloud.CSharp test lane"",""terminalId"": ""123"",""activationCode"": ""{{ACTIVATION_CODE}}""}";

                data = data.Replace("{{ACTIVATION_CODE}}", activationCode);
                txtRequest.Text = data;

                var webRequest = new HttpSender();
                var response = webRequest.Send(data, url, "json", "POST", GetHeaders());
                txtResponse.Text = response;
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnGetLanes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/cloudapi/v1/lanes/";
                var webRequest = new HttpSender();
                var response = webRequest.Send(string.Empty, url, "json", "GET", GetHeaders());
                txtResponse.Text = response;
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnCreditTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/api/v1/sale";

                string data = @"{""laneId"": {{LANEID}},""transactionAmount"": ""{{AMOUNT}}"",""invokeManualEntry"": ""{{INVOKEMANUALENTRY}}"",""displayTransactionAmount"": ""{{DISPLAYTRANSACTIONAMOUNT}}"",	""configuration"" : {""allowDebit"":""true"",""isGiftSupported"":""false""}}";

                data = data.Replace("{{LANEID}}", "1");
                data = data.Replace("{{AMOUNT}}", "1.35");
                data = data.Replace("{{INVOKEMANUALENTRY}}", "false");
                data = data.Replace("{{DISPLAYTRANSACTIONAMOUNT}}", "true");
                txtRequest.Text = data;

                var webRequest = new HttpSender();
                var response = webRequest.Send(data, url, "json", "POST", GetHeaders());
                txtResponse.Text = response;
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private Dictionary<string,string> GetHeaders()
        {
            var configData = new ConfigurationData();

            var headerDict = new Dictionary<string, string>();
            headerDict.Add("tp-application-id", configData.ApplicationId);
            headerDict.Add("tp-application-name", configData.ApplicationName);
            headerDict.Add("tp-application-version", configData.ApplicationVersion);
            headerDict.Add("tp-authorization", "Version=2.0");
            headerDict.Add("tp-express-acceptor-id", configData.AcceptorId);
            headerDict.Add("tp-express-account-id", configData.AccountId);
            headerDict.Add("tp-express-account-token", configData.AccountToken);
            headerDict.Add("tp-request-id", Guid.NewGuid().ToString());

            return headerDict;
        }

        private string GetGiftSaleXML(double amount, string encryptedTrack2Data, string cardDataKeySerialNumber, string encryptedFormat, string magneprintData)
        {

            XNamespace express = "https://transaction.elementexpress.com";
            var configurationData = new ConfigurationData();                 

            XDocument doc = new XDocument(new XElement(express + "GiftCardSale",
                                new XElement(express + "Credentials",
                                    new XElement(express + "AccountID", configurationData.AccountId),
                                    new XElement(express + "AccountToken", configurationData.AccountToken),
                                    new XElement(express + "AcceptorID", configurationData.AcceptorId)
                                            ),
                                new XElement(express + "Application",
                                    new XElement(express + "ApplicationID", configurationData.ApplicationId),
                                    new XElement(express + "ApplicationVersion", configurationData.ApplicationVersion),
                                    new XElement(express + "ApplicationName", configurationData.ApplicationName)
                                            ),
                                new XElement(express + "Terminal",
                                    new XElement(express + "TerminalID", "01"),
                                    new XElement(express + "StoreCardID", configurationData.StoreCardID),
                                    new XElement(express + "StoreCardPassword", configurationData.StoreCardPassword),
                                    new XElement(express + "CardholderPresentCode", "0"),
                                    new XElement(express + "CardInputCode", "0"),
                                    new XElement(express + "TerminalCapabilityCode", "0"),
                                    new XElement(express + "TerminalEnvironmentCode", "0"),
                                    new XElement(express + "CardPresentCode", "0"),
                                    new XElement(express + "MotoECICode", "0"),
                                    new XElement(express + "CVVPresenceCode", "0")
                                            ),
                                new XElement(express + "Transaction",
                                    new XElement(express + "TransactionAmount", amount.ToString("F")),
                                    new XElement(express + "ReferenceNumber", Guid.NewGuid().ToString()),
                                    new XElement(express + "TicketNumber", "12345"),
                                    new XElement(express + "PartialApprovedFlag", "1"),
                                    new XElement(express + "MarketCode", "7")
                                            ),
                                new XElement(express + "Card",
                                    String.IsNullOrEmpty(encryptedTrack2Data) ? null : new XElement(express + "EnctypedTrack2Data", encryptedTrack2Data),
                                    String.IsNullOrEmpty(magneprintData) ? null : new XElement(express + "MagneprintData", magneprintData),                                    
                                    new XElement(express + "CardDataKeySerialNumber", cardDataKeySerialNumber),
                                    new XElement(express + "EncryptedFormat", encryptedFormat.Replace("Format",""))
                                            )
                                        )
                            );

            return doc.ToString();
        }


        private void btnGiftTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/api/v1/card/financial/1?isEncryptedDataNeeded=true";

                var headerDict = GetHeaders();

                var webRequest = new HttpSender();
                var response = webRequest.Send(string.Empty, url, "json", "GET", headerDict);
                txtResponse.Text = response;

                dynamic data = JsonConvert.DeserializeObject(response);
                string magnePrintData = data.encryptedCardData.magneprintData; // this is populated for verifone devices
                string keySerial = data.encryptedCardData.cardDataKeySerialNumber;
                string format = data.encryptedCardData.encryptedFormat;
                string encryptedTrack2 = data.encryptedCardData.encryptedTrack2Data; //this is populated for ingenico devices
                var giftSale = GetGiftSaleXML(1.23, encryptedTrack2, keySerial, format, magnePrintData);
                txtRequest.Text += "\n\n";
                txtRequest.Text += giftSale;

                var webRequest2 = new HttpSender();
                var configData = new ConfigurationData();
                url = configData.ExpressXMLEndpoint;
                var response2 = webRequest2.Send(giftSale, url, "xml", "POST", null);
                var giftCardSaleResponse = new GiftSaleResponse(response2);
                txtResponse.Text += response2;

            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnGiftActivate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/api/v1/gift/activate";
                var configData = new ConfigurationData();

                string data = @"{""laneId"": {{LANEID}},""transactionAmount"": ""{{AMOUNT}}"",	""storeCard"" : {""Id"":""{{STORECARDID}}"",""Password"":""{{STORECARDPASSWORD}}""}}";

                data = data.Replace("{{LANEID}}", "1");
                data = data.Replace("{{AMOUNT}}", "500.00");
                data = data.Replace("{{STORECARDID}}", configData.StoreCardID);
                data = data.Replace("{{STORECARDPASSWORD}}", configData.StoreCardPassword);
                txtRequest.Text = data;

                var webRequest = new HttpSender();
                var response = webRequest.Send(data, url, "json", "POST", GetHeaders());
                txtResponse.Text = response;
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnGiftBalance_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/api/v1/balance";
                var configData = new ConfigurationData();

                string data = @"{""laneId"": {{LANEID}},""storeCard"" : {""Id"":""{{STORECARDID}}"",""Password"":""{{STORECARDPASSWORD}}""}}";

                data = data.Replace("{{LANEID}}", "1");
                data = data.Replace("{{STORECARDID}}", configData.StoreCardID);
                data = data.Replace("{{STORECARDPASSWORD}}", configData.StoreCardPassword);
                txtRequest.Text = data;

                var webRequest = new HttpSender();
                var response = webRequest.Send(data, url, "json", "POST", GetHeaders());
                txtResponse.Text = response;
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnGiftReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string url = "https://triposcert.vantiv.com/api/v1/gift/reload";
                var configData = new ConfigurationData();

                string data = @"{""laneId"": {{LANEID}},""transactionAmount"": ""{{AMOUNT}}"",	""storeCard"" : {""Id"":""{{STORECARDID}}"",""Password"":""{{STORECARDPASSWORD}}""}}";

                data = data.Replace("{{LANEID}}", "1");
                data = data.Replace("{{AMOUNT}}", "500.00");
                data = data.Replace("{{STORECARDID}}", configData.StoreCardID);
                data = data.Replace("{{STORECARDPASSWORD}}", configData.StoreCardPassword);
                txtRequest.Text = data;

                var webRequest = new HttpSender();
                var response = webRequest.Send(data, url, "json", "POST", GetHeaders());
                txtResponse.Text = response;
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
