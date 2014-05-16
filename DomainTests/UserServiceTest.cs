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

            //Act
            IEnumerable<User> result = _service.GetFriendsOnline() as IEnumerable<User>;
            //Assert
           Assert.IsTrue(result.Count()>0);
        }
    }
}
