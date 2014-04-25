using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vk.Interfaces.DAL;

namespace Vk.Interfaces.Api
{
   public interface IVkApi
   {
       bool IsAuthorized { get; }
       XmlDocument RunRequest(IMethod method);
       XmlDocument RunRequest(NameValueCollection parameters);
       void Authorize(string login, string pass);
   }
}
