using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Api;
using NUnit.Framework;
using Vk.DTO.Domain;
using Vk.Interfaces.Api;
namespace TestVkAuth
{
    [TestFixture]
    class TestVkApi
    {
        private IVkApi api;
        [Test]
        public void MethodManager_LoadMethods_Normal_Passed()
        {
            //Arrange
            string fileName = @"C:\Users\Andrew\Documents\GitHub\Vk.DTO.API\VkApi\bin\Debug\Params.xml";
            string expected_name = "messages.get";
            Dictionary<string, VkMethod> methodsList = new Dictionary<string, VkMethod>();
            VkMethodManager manager = new VkMethodManager();
            
            //Act
            manager.LoadMethods(fileName);
            
            //Assert
            Assert.AreEqual(expected_name, manager.methods["messages.get"].Name);
        }

        [SetUp]
        public void SetupTest(){
            api = VkApi.getInstance;

        }

        
    }
}
