using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vk.DTO.Domain;

namespace Vk.DTO.Services.Commands
{
    public abstract class VkCommand
    {
        protected VkService manager; //reciever
        internal IEnumerable<VkModel> vkObject;

        public virtual IEnumerable<VkModel> Execute()
        {
            return vkObject; 
            
        }
    }
}
