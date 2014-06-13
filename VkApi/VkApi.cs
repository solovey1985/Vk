/* 
 * Предназначен для 
 * формирования запросов к API 
 * и обработке отвтеов в виде XML документов
 * 
 */

using System.Collections.Specialized;
using System.Xml;
using Vk.Interfaces.Api;
using Vk.Interfaces.DAL;
using Vk.DTO.Auth;
using Vk.Interfaces.Api;
using Vk.DTO.Domain;


namespace Vk.DTO.Api
{
    public class VkApi: IVkApi
    {
        private VkRequestBuilder requestBuilder;
        private VkMethodManager methodManager;
        private VkResponse response;
        private VkRequest request;
        private VkAuthManager authManager;

        #region Properties
        public bool IsAuthorized
        {
            get
            {
                //Авторизован если в настройках есть запись access_token и он непросрочен
                if (authManager.IsExpired())
                    return false;
                return true;
            }
        }
        #endregion

        public VkApi(){
            requestBuilder= new VkRequestBuilder();
            methodManager = new VkMethodManager();
            authManager = new VkAuthManager();
        }

        private sealed class ApiCreator
        {
            private static readonly VkApi instance = new VkApi();

            public static VkApi Instance {get { return instance; }}
        }

        public static IVkApi getInstance{ get { return ApiCreator.Instance; }}
        
        public XmlDocument RunRequest(NameValueCollection parameters){
            

            //сформировать метод
            IMethod method = methodManager.SetMethod(parameters);
            
            //передать в построитель запросов
            request = new VkRequest();
            request = requestBuilder.GetRequest(method);
            
            //получить и выполнить запрос
            //получить ответ
            response = new VkResponse();
            response.GetXmlResponse(request.RequestString);
            
            //вернуть ответ в нужной форме
            return response.GetResponse();
        }

        public void Authorize(string login, string pass)
        {
            if (authManager == null)
                authManager = new VkAuthManager();

            authManager.GetRealAuth(login, pass);
        }
        
        public XmlDocument RunRequest(IMethod method)
        {
            //передать в построитель запросов
            request = new VkRequest();
            request = requestBuilder.GetRequest(method);
            
            //получить и выполнить запрос
            //получить ответ
            response = new VkResponse();
            response.GetXmlResponse(request.RequestString);
            
            //вернуть ответ в нужной форме
            return response.GetResponse();
        }
    }
}
