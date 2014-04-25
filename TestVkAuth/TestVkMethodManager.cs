using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Mocks;
using Vk.DTO.Domain;
using Vk.DTO.Domain;
using NUnit.Framework;
namespace TestVkAuth
{
    [TestFixture]
    class TestVkMethodManager
    {
        [Test]
        public void SetMethod_MessagesGet_Passed()
        {
            //Arrange
            VkMethodManager manager = new VkMethodManager();
            manager.LoadMethods(@"C:\Users\Andrew\Documents\GitHub\Vk.DTO.API\VkApi\bin\Debug\Params.xml");
            VkMethod expecteMethod = new VkMethod("messages.get");
            VkParameter count = new VkParameter("count","",true, "20");
            VkParameter inbox = new VkParameter("out", "", true, "0"); 
            expecteMethod.AddParameter(count);
            expecteMethod.AddParameter(inbox);
            
            //Act
            //IMethod actulaMethod = manager.SetMethod(new NameValueCollection());

            //Assert
            //Assert.AreEqual(expected: expecteMethod.Name, actual: actulaMethod.Name);
        }

    }
}
