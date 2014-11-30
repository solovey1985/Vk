using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkInterfaces.V2;

namespace Vk2
{
    public class Method: IMethod
    {
        public string Name { get; set; }
        public List<IParameter> Parameters { get; set; }

        public Method()
        {
            Parameters = new List<IParameter>();
        }
    }

    public class Parameter: IParameter{
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Required { get; set; }
        public string Excludes { get; set; }
    }
}
