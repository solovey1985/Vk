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
        private FriendsVM _viewModel;

        [TestFixtureSetUp]
        private void SetUp()
        {
            _controller = new UserController();    
        }

        [Test]
        public void Test_ViewModel_Load()
        {
            //Arrange
            _controller.Login("solovey1985@ukr.net", "Dhjnvytyjub1");
            //Act
            _viewModel = _controller.LoadUsersOnlineViewModel();
            //Assert
            Assert.NotNull(_viewModel);


        }
    }
}
