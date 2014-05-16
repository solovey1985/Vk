using System.Collections.Generic;
using System.Linq;
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
            parameters["fields"] = getUserFields();
            parameters["uids"] = setUsersIds(usersId);
            
            response = api.RunRequest(parameters);
            ParseAnswer();
            
            return vkObject;
        }

        public IEnumerable<VkModel> friendsGet(string userId)
        {
            ClearParameters();
            parameters["method"] = "getProfiles";
            parameters["uids"] = userId;

            response = api.RunRequest(parameters);
            ParseAnswer();
            
            return vkObject;
        }

        public IEnumerable<VkModel> GetFriendsOnline()
        {
            ClearParameters();
            parameters["method"] = "friends.getOnline";
            response = api.RunRequest(parameters);
            ParseAnswer();
            List<User> usersOnLine = new List<User>();
            foreach (VkModel model in vkObject){

                usersOnLine.Add(
                    (
                    friendsGet(((User) model).Uid)).First() as User);
            }
           
            return usersOnLine;
        }


        /// <summary>
        ///     Формирование строчки ID пользователей
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns></returns>
        private string setUsersIds(string[] usersId)
        {
            string uids = string.Empty;
            
            for (int i = 0; i < usersId.Length; i++){
                uids += usersId[i];
                if (i < usersId.Length - 1)
                    uids += ",";
            }
            
            return uids;
        }

        /// <summary>
        ///     Формирование строки полей информации о пользователях
        /// </summary>
        /// <returns></returns>
        private string getUserFields()
        {
            string userFields = string.Empty;
            userFields =
                "uid, first_name, last_name, last_seen, counters, nickname, relation, sex, birthdate, city, country, timezone, photo, photo_big, photo_rec, photo_50, online";
            
            return userFields;
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
    }
}
