using System;
using NUnit.Framework;
using Vk.DTO.Controllers;
using Vk.DTO.ViewModels;
namespace DomainTests
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController _controller;
        private FriendsOnlineVM _viewModel;

        [TestFixtureSetUp]
        private void SetUp()
        {
            _controller = new UserController();    
        }

        [Test]
        public void Test_ViewModel_Load()
        {
            //Arrange

            //Act
            _viewModel = _controller.LoadUsersOnlineViewModel();
            //Assert
            Assert.NotNull(_viewModel);
            Assert.NotNull(_viewModel.UsersOnline);

        }
    }
}
