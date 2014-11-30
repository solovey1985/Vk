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
    public interface IApi
    {}

    public interface IVkApi : IApi
   {
       bool IsAuthorized { get; }
       //TODO Избавиться от лишнего метода
       XmlDocument RunRequest(IMethod method);
       XmlDocument RunRequest(NameValueCollection parameters);
       void Login(string login, string pass);
   }

    public interface IApiResponse{}

    public interface IApiRequest{}

    public interface IXmlResponse : IApiResponse{}

    public interface IJsonResponse : IApiResponse{}


}
