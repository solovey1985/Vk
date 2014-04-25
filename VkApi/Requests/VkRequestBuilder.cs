using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Vk.Interfaces.DAL;
using Vk.DTO.Domain;

namespace Vk.DTO.Api
{
    internal class VkRequestBuilder
    {
        private VkRequest currentRequest;
        private IMethod currentMethod;

        public VkRequestBuilder(){
            currentRequest = new VkRequest();
        }
        
        public VkRequest GetRequest(IMethod method)
        {
            currentMethod = method;
            if (method != null)
                BuildRequest();
            
            return this.currentRequest;
        }

        private void BuildRequest()
        {
            currentRequest.SetMethod(currentMethod);
            currentRequest.SetRequestString();
            
        }
    }
}
