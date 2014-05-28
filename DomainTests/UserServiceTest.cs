using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vk.DTO.Controllers;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;

namespace DomainTests
{
    [TestFixture]
    public class UserServiceTest
    {
        private UserService _service;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _service = new UserService();         
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _service = null;
        }


        [Test]
        public void GetUsersOnlineTest_ValidData_Success()
        {
            //Arrange
            
            _service.Authorize("solovey1985@ukr.net", "Dhjnvytyjub1");
            //Act
            IEnumerable<User> result = _service.friendsGetOnline() as IEnumerable<User>;
            //Assert
           Assert.NotNull(result);
           Assert.Greater( result.Count(),0);
        }

       
    }
}
