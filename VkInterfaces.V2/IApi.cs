using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkInterfaces.V2
{
    public interface IApi
    {}

    public interface IVkApi: IApi{}

    public interface IFbApi : IApi{}

    public interface IApiRequest
    {}

    public interface IApiResponse{}

    public interface IXmlResponse{}

    public interface IJsonResponse{}
}
