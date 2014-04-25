using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.DTO.Services.Commands
{
    class UserCommand:VkCommand
    {
        public UserCommand()
        {
            manager = new UserService();
        }
    }
}
