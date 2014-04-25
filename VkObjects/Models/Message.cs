using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using IMessage = Vk.Interfaces.Domain.IMessage;
using System.Xml.Serialization;

namespace Vk.DTO.Domain
{
    public class Message:VkModel, IMessage
    {
        [XmlElement("mid")]
        public string Mid { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("body")]
        public string Body { get; set; }

        [XmlElement("out")]
        public string Out { get; set; }

        [XmlElement("uid")]
        public string Uid { get; set; }

        [XmlElement("read_state")]
        public string Read_state { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }
    }
}
