using System;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Controllers;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;
using log4net;
namespace Vk.DTO.Controllers
{
    public class VkController : IController
    {
        private UserSession userSession;
        internal static readonly ILog logger = LogManager.GetLogger(typeof(VkController)); 
        public bool IsAuthorized {get { return userSession.IsUserAuthorized; }}

        public VkController()
        {
            userSession = new UserSession();
            
            log4net.Config.XmlConfigurator.Configure();
        }

        #region Properties
        public UserSession UserSession 
       { 
           get {
               if (userSession == null) 
                   userSession=new UserSession(); 
           return userSession;
           }  
       }
        #endregion

       internal IBaseService _service;
         
       public IViewModel Bind(string viewName){
           return loadModel();
       }

       public virtual IViewModel loadModel(){
             return new ViewModel();
        }

        public bool Login()
        {
            return _service.Authorize(userSession.GetLogin(), userSession.GetPass());
        }

        public bool Login(string login, string pass)
        {
            if (!(String.IsNullOrEmpty(login) || String.IsNullOrEmpty(pass))){
                this.userSession.Login = login;
                this.userSession.Pass = pass;
                return this.Login();
            }
            return false;
        }
        
    }
}
