using System;
using System.Collections.Generic;
using Vk.DTO.Domain;
using Vk.DTO.Services;

namespace Vk.DTO.Services.Commands
{
   public class CmdGetUserMessages:MessageCommand
    {
        private int _count;
        private MessageDirection _out;
        public CmdGetUserMessages(int count, MessageDirection messageDirection)
        {
            this._count = count;
            this._out = messageDirection;
        }
        //
        public override IEnumerable<VkModel> Execute()
        {
          //Обработка ответа и возврат объекта
           return ((MessageService)manager).messagesGet(_count, _out);;
        }

    }
}
