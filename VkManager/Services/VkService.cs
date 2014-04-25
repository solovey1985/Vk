using System.Collections.Generic;
using System.Collections.Specialized;
using Vk.DTO.Domain;
using  System.Xml;
using Vk.DTO.Services.Parser;
using Vk.Interfaces.Api;
using Vk.Interfaces.Domain;
using Vk.Interfaces.ViewModels;
using Vk.Interfaces.Services;
using Vk.DTO;
namespace Vk.DTO.Services
{
    public abstract class VkService: IBaseService
    {
        internal NameValueCollection parameters;
        public IVkApi api { get; set; }
        public IViewModel viewModel { get; set; }
        internal IEnumerable<VkModel> vkObject;
        internal XmlDocument response;
        internal VkParser parser;
        
        public bool IsAthorized {get { return api.IsAuthorized; }}

        public VkService(){
            api = ServiceFactory.GetService<IVkApi>();
            parameters = new NameValueCollection();
        }

        public abstract IViewModel GetViewModel();
    
        internal void ClearParameters()
        {
            this.parameters.Clear();
        }

        internal abstract void ParseAnswer();

        public virtual bool Authorize(string login, string pass)
        {
            if (api.IsAuthorized){
                return true;}
            api.Authorize(login, pass);
                if (api.IsAuthorized){
                    return true;
                }
            return false;
        }
       

        
    }

}
