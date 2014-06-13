using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Castle.Components.DictionaryAdapter;
using Vk.DTO.Domain;
using Vk.DTO.Services.Parser;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.Services
{
    public class UserService : VkService, IUserService
    {
        
        public IEnumerable<VkModel> usersGet(string[] usersId)
        {
            ClearParameters();
            parameters["method"] = "users.get";
            parameters["uids"] = setUsersIds(usersId);
            response = api.RunRequest(parameters);
            ParseAnswer();
            
            return vkObject;
        }

        public IEnumerable<VkModel> friendsGet(string userId="")
        {
            ClearParameters();
            parameters["method"] = "friends.get";
            if (!String.IsNullOrEmpty(userId))
            parameters["uids"] = userId;

            response = api.RunRequest(parameters);
            ParseAnswer();
            
            return vkObject;
        }

        public IEnumerable<VkModel> friendsGetOnline()
        {
            ClearParameters();
            parameters["method"] = "friends.getOnline";
            response = api.RunRequest(parameters);
            ParseAnswer();

            List<User> usersOnLine = getFriendsOnlineIds().ToList();
            string[] userIds = usersOnLine.Select(i=>i.Uid).ToArray();
            IEnumerable<User> users = (IEnumerable<User>) usersGet(userIds);             
            return users;
        }
        
        internal override void ParseAnswer()
        {
            parser = new UserParser();
            parser.SetResponse(response);
            vkObject = parser.ParseResponse();
        }

        public override IViewModel GetViewModel()
        {
            return viewModel;
        }


        #region Private Methods
        
        /// <summary>
        ///     Формирование строчки ID пользователей
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns></returns>
        private string setUsersIds(string[] usersId)
        {
            string uids = string.Empty;

            for (int i = 0; i < usersId.Length; i++)
            {
                uids += usersId[i];
                if (i < usersId.Length - 1)
                    uids += ",";
            }

            return uids;
        }

        private IEnumerable<User> getFriendsOnlineIds(){
            IEnumerable<User> userListWithId = new List<User>();

            parameters.Clear();
            parameters["method"] = "friends.getOnline";
            XmlDocument resp = api.RunRequest(parameters);
            UserParser parser = new UserParser();
            parser.SetResponse(resp);
            userListWithId = parser.ParseResponse() as IEnumerable<User>;
            return userListWithId;
        }

        #endregion
    }
}
