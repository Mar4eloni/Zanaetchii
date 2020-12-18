using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Zanaetcii.Entities.Context;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Models;
using System.Linq;
using Zanaetchii.Controllers;
using AutoMapper;
using Zanaetchii.Profiles;
using Microsoft.AspNetCore.Mvc;
using Zanaetchii.Models.ViewModels;

namespace Zanaetchii.Tests.Controllers
{
    [TestClass]
    public class WorkFieldsControllerTests
    {
        private Mock<MyDbContext> _mockDb = new Mock<MyDbContext>();
        private Mock<IWorkFieldsRepo> _mockContext;
        private static IMapper _mapper;
        private WorkFieldsController _controller;

        public WorkFieldsControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapingProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var data = new List<WorkField>()
            {
                new WorkField{ WorkFieldId = 1, Name = "Kujumdzija" },
                new WorkField{ WorkFieldId = 2, Name = "Kovac" },
                new WorkField{ WorkFieldId = 3, Name = "Rezbar" }
            }.AsQueryable();
            _mockContext = new Mock<IWorkFieldsRepo>();

            _mockContext.Setup(m => m.GetAll()).Returns(data);
            _mockContext.Setup(m => m.Get(1)).Returns(data.ElementAt(1));
            //_mockContext.Setup(m => m.Get(2)).Returns(data.ElementAt(2));
            //_mockContext.Setup(m => m.Get(3)).Returns(data.ElementAt(3));
            _controller = new WorkFieldsController(_mockContext.Object, _mapper);
        }
        [TestMethod]
        public void TestControllerInjectionForMapperAndRepo()
        {
            //Arrange

            //Act 
            var result = _controller.Index() as ViewResult;
            var actualresult = result.Model;
            //var actualresult2 = result.Model as List<WorkFieldViewModel>;
            //Assert
            Assert.IsInstanceOfType(result,typeof(ViewResult));
            Assert.IsInstanceOfType(actualresult, typeof(List<WorkFieldViewModel>));
            
        }
        [TestMethod]
        public void TestIndexView()
        {
            var result = _controller.Index() as ViewResult;
            var actualresult = result.Model;

            Assert.IsNotNull(result);
            Assert.IsNotNull(actualresult);
        }
        [TestMethod]
        public void TestCreateGetAction()
        {
            var result = _controller.Create() as ViewResult;
            var actualresult = result.Model;

            Assert.IsInstanceOfType(result,typeof(ViewResult));
            Assert.IsInstanceOfType(actualresult, typeof(WorkFieldViewModel));
        }
        [TestMethod]
        public void TestCreatePostAction()
        {
            //Arrange
            var test = new WorkFieldViewModel { WorkFieldId = 0, Name = "Test" };
            //Act
            var result = _controller.Create(test);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void TestEditGetAction()
        {
            //Arrange
            int id = 3;
            _mockContext.Setup(m => m.Get(id)).Returns(new WorkField { WorkFieldId = 3, Name = "Rezbar" });
            //Act
            var result = _controller.Edit(id) as ViewResult;
            var resultModel = result.Model;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(resultModel, typeof(WorkFieldViewModel));
            Assert.IsNotNull(resultModel);
            //Assert.IsTrue((WorkFieldViewModel)resultModel)
        }
        [TestMethod]
        public void TestEditPostAction()
        {
            //Arrange
            int id = 3;
            var test = new WorkFieldViewModel { WorkFieldId = 3, Name = "Test" };
            //Act
            var result = _controller.Edit(id,test);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}
