using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;

namespace Vk.DTO.Services.Commands
{
    class CmdGetUserFriends: UserCommand
    {
        private string _usersId;

        public CmdGetUserFriends(string usersId){
            _usersId = usersId;
        }
        public override IEnumerable<VkModel> Execute(){
            //Обработка ответа и возврат объекта
            return ((UserService)manager).friendsGet(_usersId); ;
        }

    }
}
