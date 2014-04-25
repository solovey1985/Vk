using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Vk.DTO.Api
{
    public class VkResponse
    {
        private XmlDocument xmlResponse;
        private bool IsXml;

        public VkResponse(){
            xmlResponse = new XmlDocument();
            IsXml = true;
        }
        internal void GetXmlResponse(string requestUri)
        {
            this.xmlResponse = new XmlDocument();
            this.xmlResponse.Load(requestUri);
        }

        public XmlDocument GetResponse()
        {
            return xmlResponse;
        }
    }
}
