using System.Configuration;

namespace triPOSCloud.CSharp
{
    public class ConfigurationData
    {
        public string AccountId = string.Empty;
        public string AccountToken = string.Empty;
        public string AcceptorId = string.Empty;
        public string ApplicationId = string.Empty;
        public string ApplicationVersion = string.Empty;
        public string ApplicationName = string.Empty;
        public string ExpressXMLEndpoint = string.Empty;
        public string ExpressReportingXMLEndpoint = string.Empty;
        public string TriPOSCloudLaneEndpoint = string.Empty;
        public string TriPOSCloudTransactionEndpoint = string.Empty;
        public string StoreCardID = string.Empty;
        public string StoreCardPassword = string.Empty;

        public ConfigurationData()
        {
            AccountId = ConfigurationManager.AppSettings["AccountID"];
            AccountToken = ConfigurationManager.AppSettings["AccountToken"];
            AcceptorId = ConfigurationManager.AppSettings["AcceptorID"];
            ApplicationId = ConfigurationManager.AppSettings["ApplicationID"];
            ApplicationVersion = ConfigurationManager.AppSettings["ApplicationVersion"];
            ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
            ExpressXMLEndpoint = ConfigurationManager.AppSettings["ExpressXMLEndpoint"];
            ExpressReportingXMLEndpoint = ConfigurationManager.AppSettings["ExpressReportingXMLEndpoint"];
            TriPOSCloudLaneEndpoint = ConfigurationManager.AppSettings["triPOSCloudLaneEndpoint"];
            TriPOSCloudTransactionEndpoint = ConfigurationManager.AppSettings["triPOSCloudTransactionEndpoint"];
            StoreCardID = ConfigurationManager.AppSettings["StoreCardID"];
            StoreCardPassword = ConfigurationManager.AppSettings["StoreCardPassword"];
        }
    }
}
