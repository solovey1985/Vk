using System.Collections.Generic;
using System.Xml;
using Vk.DTO.Domain;

namespace Vk.DTO.Services.Parser
{
    class UserParser: VkParser
    {
        internal override IEnumerable<VkModel> ParseResponse()
        {
            List<User> userList = new List<User>();
            XmlNodeList usersNodes = response.SelectNodes("//user");
            if (usersNodes.Count > 0){
                foreach (XmlNode node in usersNodes){
                    User user = new User();

                    user.Uid = GetNodeValue(node, "uid");
                    user.First_name = GetNodeValue(node, "first_name");
                    user.Last_name = GetNodeValue(node, "last_name");
                    user.Online = GetNodeValue(node, "online");
                    user.Photo_100 = GetNodeValue(node, "photo_rec");
                    user.Photo = GetNodeValue(node, "photo_big");
                    user.Sex = GetNodeValue(node, "sex");
                    user.Last_seen = GetNodeValue(node, "last_seen");

                    userList.Add(user);
                }
            }
            else{
                 usersNodes = response.SelectNodes("//uid");
                 foreach (XmlNode node in usersNodes)
                 {
                     User user = new User();

                     user.Uid = node.InnerText;
                     userList.Add(user);
                 }
            }
            return userList;
        }
        
        internal override void SetResponse(System.Xml.XmlDocument response)
        {
            this.response = response;
        }
    }
}
