using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using Vk.DTO.Services;

namespace Vk.DTO.Services.Commands
{
    class CmdGetHistoryWithUser:MessageCommand
    {
        private int _count;
        private string _uid;
        public CmdGetHistoryWithUser(string uid, int count)
        {
            manager = new MessageService();
            this._count = count;
            this._uid = uid;
        }
   
        public override IEnumerable<VkModel> Execute(){
            //Обработка ответа и возврат объекта
           return ((MessageService)manager).messagesGetHistory(_uid, _count);
        }
    }
}
