using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Zanaetchii.Contracts.Interfaces;
using Zanaetchii.Contracts.Services;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Tests.Repositories
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private Mock<MyDbContext> _mockDb = new Mock<MyDbContext>();
        private Mock<IGenericRepository<WorkField>> _mockContext;

        [TestInitialize]
        public void TestInitialize()
        {
            var data = new List<WorkField>()
            { 
                new WorkField{ WorkFieldId = 1, Name = "Kujumdzija" },
                new WorkField{ WorkFieldId = 2, Name = "Kovac" },
                new WorkField{ WorkFieldId = 3, Name = "Rezbar" }
            }.AsQueryable();
            _mockContext = new Mock<IGenericRepository<WorkField>>();
            
            _mockContext.Setup(m => m.GetAll()).Returns(data);
            _mockContext.Setup(m => m.Get(1)).Returns(data.ElementAt(1));
            //_mockContext.Setup(m => m.Get(2)).Returns(data.ElementAt(2));
            //_mockContext.Setup(m => m.Get(3)).Returns(data.ElementAt(3));
            
        }

        [TestMethod]
        public void GetAllTestReturnsValue()
        {
            var result = _mockContext.Object.GetAll();

            Assert.IsTrue(result.Count() == 3);
        }
        [TestMethod]
        public void GetByIdGetsCorrectItem()
        {
            var result = _mockContext.Object.Get(1);

            Assert.IsTrue(result.WorkFieldId == 2);
        }
        [TestMethod]
        public void GetbyIdGetsFalseItem()
        {
            var result = _mockContext.Object.Get(1);

            Assert.IsTrue(result.WorkFieldId != 3);
        }
    }
}
