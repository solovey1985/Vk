using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vk.Interfaces.Domain;

namespace Vk.DTO.Domain
{
    
    [XmlRoot("user")]
    public class User: VkModel, IUser
    {
        [XmlElement ("uid")]
        public string Uid { get; set; }

        [XmlElement("first_name")]
        public string First_name { get; set; }

        [XmlElement("last_name")]
        public string Last_name { get; set; }

        [XmlElement("photo")]
        public string Photo { get; set; }

        [XmlElement("sex")]
        public string Sex { get; set; }

        [XmlElement("bdate")]
        public string Bdate { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("photo_50")]
        public string Photo_50 { get; set; }

        [XmlElement("photo_100")]
        public string Photo_100 { get; set; }
        
        [XmlElement("photo_200_orig")]
        public string Photo_200_orig { get; set; }
        
        [XmlElement("photo_max")]
        public string Photo_max { get; set; }

        [XmlElement("photo_max_orig")]
        public string Photo_max_orig { get; set; }
        
        [XmlElement ("online")]
        public string Online { get; set; }
        
        [XmlElement("lists")]
        public string Lists { get; set; }
        
        [XmlElement("contacts")]
        public string Contacts { get; set; }
        
        [XmlElement("screen_name")]
        public string Screen_name { get; set; }
        
        [XmlElement("ahs_mobile")]
        public string Has_mobile { get; set; }

        public string Can_post { get; set; }
        
        [XmlElement("last_seen")]
        public string Last_seen { get; set; }

    }
}

/*
<uid>1</uid>
<>Павел</first_name>
<>Дуров</last_name>
<>http://cs109.vkontakte.ru/u00001/c_df2abf56.jpg</photo>
</user>
<user>
<uid>6492</uid>
<first_name>Andrew</first_name>
<last_name>Rogozov</last_name>
<photo>http://cs537.vkontakte.ru/u06492/c_28629f1d.jpg</photo>

 */