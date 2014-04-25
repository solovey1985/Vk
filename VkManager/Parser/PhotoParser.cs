using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vk.DTO.Domain;
using Vk.Interfaces.Domain;
using VkUtillites.Time;

namespace Vk.DTO.Services
{
    internal class PhotoParser: VkParser
    {

        internal override IEnumerable<VkModel> ParseResponse()
        {
            
            List<Photo> photoList = new List<Photo>();
            XmlNodeList nodes = response.SelectNodes("//photo");
            foreach (XmlNode node in nodes){
                Photo photo = new Photo();
                photo.Id = GetNodeValue(node, "pid");
                photo.Album_id = GetNodeValue(node, "aid");
                photo.Uid = GetNodeValue(node, "owner_id");
                photo.Created = TimeHelper.GetTime(GetNodeValue(node, "created")).ToString();
                photo.Src = GetNodeValue(node, "src");
                photo.Src_big = GetNodeValue(node, "src_big");
                photo.Src_small = GetNodeValue(node, "src_small");
                photo.Text= GetNodeValue(node, "text");
                
                photoList.Add(photo);
            }
            return  photoList ;
        }

        internal override void SetResponse(XmlDocument response){
           this.response = response;
        }
    }
}
/*
<?xml version="1.0" encoding="utf-8"?>
<response list="true">
 <count>64</count>
 <photo>
  <pid>114272714</pid>
  <aid>33565378</aid>
  <owner_id>5005272</owner_id>
  <created>1214309659</created>
  <src>http://cs1437.vkontakte.ru/u5005272/33565378/m_2a07b7cb.jpg</src>
  <src_big>http://cs1437.vkontakte.ru/u5005272/33565378/x_5769a2b7.jpg</src_big>
  <src_small>http://cs1437.vkontakte.ru/u5005272/33565378/s_beb1d458.jpg</src_small>
  <text>test</text>
 </photo>
</response>
*/