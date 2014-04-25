using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Services;

namespace Vk.DTO.Services.Commands
{
    public class MessageCommand:VkCommand
    {
        internal MessageCommand()
        {
            manager = new MessageService();
        }
    }
}
