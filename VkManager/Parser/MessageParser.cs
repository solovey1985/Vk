using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Xml;
using Vk.DTO.Api.Helper.Time;
using Vk.DTO.Domain;
using Vk.Interfaces.Domain;
using IMessage = Vk.Interfaces.Domain.IMessage;
using Vk.DTO.Services.Parser;

namespace Vk.DTO.Services
{
    class MessageParser:VkParser
    {

        internal override IEnumerable<VkModel> ParseResponse()
        {
            var messageList = new List<Message>();
            XmlNodeList msgNodes = response.GetElementsByTagName("message");

            foreach (XmlNode msgNode in msgNodes)
            {
                Message msg = new Message();

                msg.Body = msgNode.SelectSingleNode("body") != null ? msgNode.SelectSingleNode("body").InnerText:"";
                msg.Title = msgNode.SelectSingleNode("title") != null ? msgNode.SelectSingleNode("title").InnerText : "";
                msg.Date = msgNode.SelectSingleNode("date") != null ? TimeHelper.GetTime( msgNode.SelectSingleNode("date").InnerText).ToString(): "";
                msg.Uid = msgNode.SelectSingleNode("uid") != null ? msgNode.SelectSingleNode("uid").InnerText : "";
                msg.Mid = msgNode.SelectSingleNode("mid")!= null ? msgNode.SelectSingleNode("mid").InnerText: "";
                msg.Read_state = msgNode.SelectSingleNode("read_state")!= null ? msgNode.SelectSingleNode("read_state").InnerText: "";
                msg.Out = msgNode.SelectSingleNode("out")!= null ? msgNode.SelectSingleNode("out").InnerText: "";

                messageList.Add(msg);
            }
            return messageList;
        }

        internal override void SetResponse(XmlDocument response)
        {
            this.response = response;
        }
    }
}
