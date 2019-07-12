

namespace UnitTestSingular
{
     
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository;
    using Util;

    [TestClass]
    public class RabbitSendingMessageTest
    {
        [TestMethod]
        public void RabbitTestSendingMessage()
        {
            new RabbitmqUtil(true).SendSerialized(new ClientRepository().dto);
        }
    }
}
