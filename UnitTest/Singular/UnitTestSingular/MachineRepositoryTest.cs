

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
        public void MachineRepositorySelectTop10MachinesTest()
        {

            IList<Machine> value = this.rep.SelectTop10Machines();

            Assert.IsTrue(value.Count > 0);
        }


        [TestMethod]
        public void MachineRepositorySelectTop10ProgramsTest()
        {

            IList<Programs> value = this.rep.SelectTop10Programs();

            Assert.IsTrue(value.Count > 0);
        }


        [TestMethod]
        public void MachineRepositorySelectKPIsTest()
        {
            IList<KPIs> value = this.rep.SelectKPIs();

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
