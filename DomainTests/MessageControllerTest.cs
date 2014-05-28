using System;
using NUnit.Framework;
using Vk.DTO.Controllers;
using Vk.DTO.ViewModels;

namespace DomainTests
{
    [TestFixture]
    public class MessageControllerTest
    {
        private MessageController messageController;

        [TestFixtureSetUp]
        public void SetUp()
        {

            messageController = new MessageController();
            
               
        }

        [Test]
        public void Test_GetMessageViewModel()
        {
            //Arrange
            MessageListViewModel messageListVM =new MessageListViewModel();
            messageController.Login("solovey1985@ukr.net","Dhjnvytyjub1");
            //Act
            messageListVM = messageController.LoadMessageListViewModel();
            //Assert
            Assert.NotNull(messageListVM.MessageVMList.Messages);
            Assert.Greater(messageListVM.MessageVMList.Messages.Count, 0);

        }
    }
}
