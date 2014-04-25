using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;

namespace Vk.DTO.Services.Commands
{
    class CmdGetUsersOnLine: UserCommand
    {
        private string[] _usersId;
        public CmdGetUsersOnLine(string[] usersId)
        {
            _usersId = usersId;
        }
        public override IEnumerable<VkModel> Execute()
        {
            //Обработка ответа и возврат объекта
            return ((UserService)manager).usersGet(_usersId); ;
        }

    }
}
