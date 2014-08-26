using System;
using System.Collections.Generic;
using Vk.Interfaces.DAL;

namespace Vk.DTO.Domain
{
    public class VkMethod: IMethod
    {
        public string Name { get; set; }
        public IEnumerable<IParameter> Parameters { get { return parameters; } }

        private List<VkParameter> parameters; 

        public VkMethod(string name){
            this.Name = name;
            parameters = new List<VkParameter>();
        }

        public void AddParameter(IParameter parameter)
        {
            parameters.Add(parameter as VkParameter);
        }

        public string GetInfo()
        {
            throw (new NotImplementedException());
        }
    }
}
