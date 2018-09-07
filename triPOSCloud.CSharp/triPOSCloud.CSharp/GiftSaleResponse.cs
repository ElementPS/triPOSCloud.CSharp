using System;
using System.Xml;

namespace triPOSCloud.CSharp
{
    public class GiftSaleResponse
    {
        public string ExpressResponseCode;
        public string ExpressResponseMessage;
        public string HostResponseMessage;
        public string ExpressTransactionDate;
        public string ExpressTransactionTime;
        public string ExpressTransactionTimezone;
        public string TransactionID;
        public string ReferenceNumber;
        public string ProcessorName;
        public string TransactionStatus;
        public string CardLogo;
        public string ApprovalNumber;
        public string TransactionStatusCode;
        public string ApprovedAmount;
        public string BalanceAmount;

        public GiftSaleResponse(string response)
        {
            ParseRespone(response);
        }

        public void ParseRespone(string response)
        {
            var xml = new XmlDocument();
            xml.LoadXml(response);
            var namespaceManager = new XmlNamespaceManager(xml.NameTable);
            namespaceManager.AddNamespace("ns", "https://transaction.elementexpress.com");            

            var tempNode = xml.SelectSingleNode("//ns:GiftCardSaleResponse/ns:Response", namespaceManager);
            ExpressResponseCode = tempNode.SelectSingleNode("ns:ExpressResponseCode", namespaceManager)?.InnerText;
            ExpressResponseMessage = tempNode.SelectSingleNode("ns:ExpressResponseMessage", namespaceManager)?.InnerText;
            HostResponseMessage = tempNode.SelectSingleNode("ns:HostResponseMessage", namespaceManager)?.InnerText;
            ExpressTransactionDate = tempNode.SelectSingleNode("ns:ExpressTransactionDate", namespaceManager)?.InnerText;
            ExpressTransactionTime = tempNode.SelectSingleNode("ns:ExpressTransactionTime", namespaceManager)?.InnerText;
            ExpressTransactionTimezone = tempNode.SelectSingleNode("ns:ExpressTransactionTimezone", namespaceManager)?.InnerText;

            tempNode = xml.SelectSingleNode("//ns:GiftCardSaleResponse/ns:Response/ns:Transaction", namespaceManager);
            TransactionID = tempNode.SelectSingleNode("ns:TransactionID", namespaceManager)?.InnerText;
            ReferenceNumber = tempNode.SelectSingleNode("ns:ReferenceNumber", namespaceManager)?.InnerText;
            ProcessorName = tempNode.SelectSingleNode("ns:ProcessorName", namespaceManager)?.InnerText;
            TransactionStatus = tempNode.SelectSingleNode("ns:TransactionStatus", namespaceManager)?.InnerText;
            ApprovalNumber = tempNode.SelectSingleNode("ns:ApprovalNumber", namespaceManager)?.InnerText;
            TransactionStatusCode = tempNode.SelectSingleNode("ns:TransactionStatusCode", namespaceManager)?.InnerText;
            ApprovedAmount = tempNode.SelectSingleNode("ns:ApprovedAmount", namespaceManager)?.InnerText;
            BalanceAmount = tempNode.SelectSingleNode("ns:BalanceAmount", namespaceManager)?.InnerText;

            tempNode = xml.SelectSingleNode("//ns:GiftCardSaleResponse/ns:Response/ns:Card", namespaceManager);
            CardLogo = tempNode.SelectSingleNode("ns:CardLogo", namespaceManager)?.InnerText;
        }
    }
}
