using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vk.Interfaces.Domain;

namespace Vk.DTO.Domain
{
    public class Photo: VkModel, IPhoto
    {
        [XmlElement("pid")]
        public string Id { get; set; }

        [XmlElement("aid")]
        public string Album_id { get; set; }

        [XmlElement("owner_id")]
        public string Uid { get; set; }

        [XmlElement("crated")]
        public string Created { get; set; }

        [XmlElement("src")]
        public string Src { get; set; }

        [XmlElement("src_big")]
        public string Src_big { get; set; }

        [XmlElement("src_small")]
        public string Src_small { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

    }
}
