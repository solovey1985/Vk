using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vk.DTO.Domain;
using Vk.DTO.Services;


namespace DomainTests
{
    [TestFixture]
    public class UserServiceTest
    {
        private UserService _service;

        [TestFixtureSetUp]
        public void SetUp()
        {
                     
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
            _service = new UserService();
            //Act
            IEnumerable<User> result = _service.friendsGetOnline() as IEnumerable<User>;
            //Assert
           Assert.NotNull(result);
           Assert.Greater( result.Count(),0);
        }
    }
}
