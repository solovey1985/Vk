/* Хранит запрос к серверу
* 
*/

using System;
using Vk.Interfaces.DAL;
using Vk.DTO.Auth;

namespace Vk.DTO.Api
{
   internal class VkRequest
    {
        private string requestURI;
        private IMethod method;
        private string _accessToken;
       private bool IsXML = true;
        private string requestString;
        

        public string RequestString{
            get { return requestString; }
            set { requestString = value; }
        }


        public VkRequest(){
            requestURI = @"https://api.vk.com/method/";
        }

        public void SetMethod(IMethod methodObject){
            this.method = methodObject;
        }
        
        
        public void SetRequestString()
        {
            if (method != null)
            {
                SetRequestUri();
                SetMethodName();
                SetIsXml();
                SetParams();
                SetAccessToken();
            }
        }

        private void SetRequestUri(){
            requestString = requestURI;
        }
       
        private void SetMethodName(){
            requestString += method.Name;
        }

        private void SetIsXml(){
            if (IsXML)
                requestString += ".xml?";
            else
                requestString += "?";
        }

        private void SetParams(){
            foreach (IParameter parameter in method.Parameters)
            {
                if (!String.IsNullOrEmpty(parameter.Value))
                requestString += parameter.Name +"=" + parameter.Value + "&";
            }     
       }
       
       private void SetAccessToken(){
          requestString += "access_token=" + VkAuthInfo.AccessToken;
      }

      
    }
}
/*
*
 * 
 *          https://api.vk.com/method/getProfiles?uid=66748&access_token=533bacf01e11f55b536a565b57531ac114461ae8736d6506a3
 * 
 * 
 */

