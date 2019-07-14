

namespace UnitTestSingular
{
    using DTO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Repository;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class MachineRepositoryTest
    {

        public MachineRepository rep { get; set; }
        [TestInitialize]
        public void MachineRepositorySetupTest()
        {
            this.rep = new MachineRepository();
        }


        [TestMethod]
        public void MachineRepositoryInsertTest()
        {
            int value = this.rep.Insert(
                new ClientDTO {
                    MachineName = "xyz-22-rbt",
                    ProgramsList= new List<string> { "winrar","open word","virtual box"},
                    DateHours = DateTime.Now
                    
                });

            Assert.IsTrue(value > 0);
        }

        [TestMethod]
        public void MachineRepositorySelectTest()
        {

            IList<Machine> value = this.rep.Select();

            Assert.IsTrue(value.Count > 0);
        }


        [TestMethod]
        public void MachineRepositoryUpdateTest()
        {
            int value = this.rep.Update(new ClientDTO
            {
                Id = 1,
                MachineName = "mac-xpto-173",
                DateHours = DateTime.Now
            });

            Assert.IsTrue(value > 0);
        }

    }
}
