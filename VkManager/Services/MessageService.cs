using System;
using System.Collections.Generic;
using System.Linq;
using Vk.DTO.Domain;
using Vk.DTO.Domain;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Domain;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;
using IMessage = System.Runtime.Remoting.Messaging.IMessage;

namespace Vk.DTO.Services
{
    public enum MessageDirection{
    In = 0,
    Out = 1
}
    class MessageService: VkService, IMessageService
    {
        public IEnumerable<VkModel> messagesGet(int count, MessageDirection messageDirection)
        {
            
            ClearParameters();    
            parameters["method"] = "messages.get";
            parameters["count"] = count.ToString();
            parameters["out"] = ((int)messageDirection).ToString();
            
            try{
                response = api.RunRequest(parameters);
            }
            catch (Exception exception){
                throw new Exception("Невозможно получить ответ от API.", exception);
            }

            if (response != null){
                ParseAnswer();
            }
            
            return  vkObject;
        }

        public IEnumerable<VkModel> messagesGetHistory(string uid, int count)
        {
            ClearParameters();
            parameters["method"] = "messages.getHistory";
            parameters["uid"] = uid;
            parameters["count"] = count.ToString();
            parameters["offset"] = "0";

            try{
                response = api.RunRequest(parameters);
                ParseAnswer();
                return vkObject;
            }
            catch (Exception exception){

                throw new Exception("Невозможно получить ответ от API.", exception);
            }
            

        }
        
        internal override void ParseAnswer()
        {
                parser = new MessageParser();
                parser.SetResponse(response);
                vkObject =  parser.ParseResponse();
        }

        public override IViewModel GetViewModel()
        {
             var messageviewModel = new MessageListViewModel();
            List<Message> messageList = messagesGet(50, MessageDirection.In) as List<Message>;
          
             List<User> userList = new UserService()
                 .usersGet(messageList.Select(x => x.Uid)
                 .Distinct()
                 .ToArray()) 
                 as List<User>;
                        
            //Происходит маппинг
            messageviewModel.MessageList = messageList;
            messageviewModel.UserList = userList;
            return messageviewModel;

        }
    }
}
