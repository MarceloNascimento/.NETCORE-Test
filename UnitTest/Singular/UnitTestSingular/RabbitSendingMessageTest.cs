

namespace UnitTestSingular
{
    using DTO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository;
    using System;
    using Util;

    [TestClass]
    public class RabbitSendingMessageTest
    {
        [TestMethod]
        public void RabbitTestSendSerializedMessage()
        {
            try
            {
                new RabbitmqUtil(true).SendSerialized(new ClientRepository().dto);

            }catch(Exception ex)
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
            
        }


        [TestMethod]
        public void RabbitTestReceiveMessage()
        {
            
            object message = new RabbitmqUtil(true).ReceiveSerialized("MACHINES-MONITOR");

            Assert.IsNotNull(message);
        }
    }
}
