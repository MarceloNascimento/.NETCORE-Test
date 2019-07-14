

namespace UnitTestSingular
{
    using DTO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository;
    using System;
    using Util;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestClass]
    public class MachineRepositoryTest
    {

        [TestMethod]
        public void MachineRepositoryInsertTest()
        {

            int value = new MachineRepository().Insert();

            Assert.IsTrue(value > 0);
        }

        [TestMethod]
        public void MachineRepositorySelectTest()
        {

            IList<Machine> value = new MachineRepository().Select();

            Assert.IsTrue(value.Count > 0);
        }


        [TestMethod]
        public void MachineRepositoryUpdateTest()
        {
            int value = new MachineRepository().Update(new ClientDTO
            {
                Id = 1,
                MachineName = "mac-xpto-173",
                DateHours = DateTime.Now
            });

            Assert.IsTrue(value > 0);
        }

    }
}
