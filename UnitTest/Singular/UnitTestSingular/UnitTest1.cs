using ClientWinService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSingular
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            new RabbitmqRepository().Send("Teste");
        }
    }
}
