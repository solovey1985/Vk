using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vk.DTO.Domain;
using Vk.Interfaces.Domain;

namespace Vk.DTO.Services
{
    public abstract class VkParser{
        internal XmlDocument response;

        public VkParser()
        {}

        public VkParser(XmlDocument response)
        {
            this.response = response;
        }

        internal abstract IEnumerable<VkModel> ParseResponse();
        internal abstract void SetResponse(XmlDocument response);

        internal string GetNodeValue(XmlNode node, string nodeName)
        {
            return node.SelectSingleNode(nodeName) != null ? node.SelectSingleNode(nodeName).InnerText : "";
        }
    }
}
