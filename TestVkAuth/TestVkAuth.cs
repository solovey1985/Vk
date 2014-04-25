using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Vk.DTO.Auth;
namespace TestVkAuth
{
    public class TestVkAuth
    {

        [Test]
        public void GetRequest_Normal_Passed()
        {
            //Arrange
            string actual_request = "";
            string expected_request =
                "https://oauth.vk.com/authorize?client_id=3863742&redirect_uri=https://oauth.vk.com/blank.html&scope=12&display=page&response_type=token";
            VkAuthManager auth = new VkAuthManager();
            //Act
            actual_request = auth.GetAuthRequest();
            //Assert
            Assert.AreEqual(expected_request, actual_request);
        }

        
    }
}
