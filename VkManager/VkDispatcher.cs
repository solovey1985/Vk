/**
 * Диспетчер обеспечивает логику конечного приложения
 * должен реализовывать возможность подключения MVVM- паттерна
 */

using System.Collections.Generic;
using Vk.DTO.Domain;
using Vk.DTO.Services.Commands;
using Vk.DTO.Auth;

namespace Vk.DTO.Services
{
   public class VkDispatcher
    {
        private VkCommand command;
        private VkModel vkObject;
       private VkAuthManager authManager;
       public VkDispatcher()
       {}
   
       /// <summary>
       /// 
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public IEnumerable<VkModel> GetLastMessages()
        {
            command = new CmdGetUserMessages(20, MessageDirection.Out);
            return command.Execute();
        }

       public IEnumerable<VkModel> GetHistoryMessagesWithUser(string uid, int count)
       {
           command = new CmdGetHistoryWithUser(uid, count);
           return command.Execute();

       }

       public IEnumerable<VkModel> UsersOnline(string[] usersId)
       {
           command = new CmdGetUsersOnLine(usersId);
           return command.Execute();
       }

       public IEnumerable<VkModel> GetUserFriend(string userId)
       {
           command = new CmdGetUserFriends(userId);
           return command.Execute();
       }

       public IEnumerable<VkModel> GetPhotoById(string uid)
       {
           command = new CmdGetPhotoByUserId(uid);
           return command.Execute();
       }
    }
}
