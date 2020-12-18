using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetchii.Controllers;
using Zanaetchii.Models.ViewModels;
using Zanaetchii.Profiles;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Tests.Controllers
{
    [TestClass]
    public class WorkerControllerTests
    {
        private Mock<MyDbContext> _mockDb = new Mock<MyDbContext>();
        private Mock<IWorkerRepo> _mockContext;
        private static IMapper _mapper;
        private WorkerController _controller;

        public WorkerControllerTests()
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
            var data = new List<Worker>()
            {
                new Worker{
                    Id = 1,
                    User = new Users {
                        Id = "12rfwerasrgh35yu" ,
                        FirstName = "Test",
                        LastName = "Test",
                        Address= "testasd",
                        BankAcc = "asfasfg2qw3gfesd12",
                        Email = "test@test.te",
                        Password = "asdasd",
                        Country = "test0",
                        UserId = 1,
                        PhoneNumber = "12235346457",
                        UserName = "sadgsfdgasdfga"
                    }
                },
                new Worker{
                    Id = 2,
                    User = new Users {
                        Id = "12rfwerasrgh35yu2" ,
                        FirstName = "Test2",
                        LastName = "Test2",
                        Address= "testasd",
                        BankAcc = "asfasfg2qw3gfesd12",
                        Email = "test@test.te",
                        Password = "asdasd",
                        Country = "test0",
                        UserId = 2,
                        PhoneNumber = "12235346457",
                        UserName = "sadgsfdgasdfga"
                    }
                },
                new Worker{
                    Id = 3,
                    User = new Users {
                        Id = "12rfwerasrgh35yu3" ,
                        FirstName = "Test3",
                        LastName = "Test3",
                        Address= "testasd",
                        BankAcc = "asfasfg2qw3gfesd12",
                        Email = "test@test.te",
                        Password = "asdasd",
                        Country = "test0",
                        UserId = 3,
                        PhoneNumber = "12235346457",
                        UserName = "sadgsfdgasdfga"
                    }
                }

            };
            _mockContext = new Mock<IWorkerRepo>();

            _mockContext.Setup(m => m.GetAll()).Returns(data);
            _mockContext.Setup(m => m.Get(1)).Returns(data[1]);

            _controller = new WorkerController(_mockContext.Object, _mapper);
        }
        [TestMethod]
        public void WorkerControllerInjectionForMapperAndRepo()
        {
            //Arrange

            //Act 
            var result = _controller.Index() as ViewResult;
            var actualresult = result.Model;
            //var actualresult2 = result.Model as List<WorkFieldViewModel>;
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(actualresult, typeof(List<WorkerViewModel>));

        }
        [TestMethod]
        public void WorkerControllerIndexView()
        {
            var result = _controller.Index() as ViewResult;
            var actualresult = result.Model;

            Assert.IsNotNull(result);
            Assert.IsNotNull(actualresult);
        }
        [TestMethod]
        public void WorkerControllerCreateGetAction()
        {
            var result = _controller.Create() as ViewResult;
            var actualresult = result.Model;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(actualresult, typeof(WorkerViewModel));
        }
        [TestMethod]
        public void WorkerControllerCreatePostAction()
        {
            //Arrange
            var test = new WorkerViewModel
            {
                Id = 3,
                User = new UserViewModel
                {
                    FirstName = "Test3",
                    LastName = "Test3",
                    Address = "testasd",
                    BankAcc = "asfasfg2qw3gfesd12",
                    Email = "test@test.te",
                    Password = "asdasd",
                    Country = "test0",
                    UserId = 3,
                }
            };
            //Act
            var result = _controller.Create(test);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void WorkerControllerEditGetAction()
        {
            //Arrange
            int id = 3;
            _mockContext.Setup(m => m.Get(id)).Returns(new Worker
            {
                Id = 3,
                User = new Users
                {
                    Id = "12rfwerasrgh35yu3",
                    FirstName = "Test3",
                    LastName = "Test3",
                    Address = "testasd",
                    BankAcc = "asfasfg2qw3gfesd12",
                    Email = "test@test.te",
                    Password = "asdasd",
                    Country = "test0",
                    UserId = 3,
                    PhoneNumber = "12235346457",
                    UserName = "sadgsfdgasdfga"
                }
            });
            //Act
            var result = _controller.Edit(id) as ViewResult;
            var resultModel = result.Model;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(resultModel, typeof(WorkerViewModel));
            Assert.IsNotNull(resultModel);
        }
        [TestMethod]
        public void WorkerControllerEditPostAction()
        {
            //Arrange
            int id = 3;
            var test = new WorkerViewModel
            {
                Id = 3,
                User = new UserViewModel
                {
                    FirstName = "Test33213",
                    LastName = "Test312312",
                    Address = "testasd",
                    BankAcc = "asfasfg2qw3gfesd12",
                    Email = "test@test.te",
                    Password = "asdasd",
                    Country = "test0",
                    UserId = 3,
                }
            };
            var entity = new Worker
            {
                Id = 3,
                User = new Users
                {
                    Id = "12rfwerasrgh35yu3",
                    FirstName = "Test3qwe",
                    LastName = "Test3qwe",
                    Address = "testasd",
                    BankAcc = "asfasfg2qw3gfesd12",
                    Email = "test@test.te",
                    Password = "asdasd",
                    Country = "test0",
                    UserId = 3,
                    PhoneNumber = "12235346457",
                    UserName = "sadgsfdgasdfga"
                }
            };
            _mockContext.Setup(m => m.Update(entity)).Returns(entity);
            //Act
            var result = _controller.Edit(id, test);
            //Assert
            Assert.IsNotNull(result);
           // Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}
