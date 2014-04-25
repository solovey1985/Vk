using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Interfaces.DAL
{
    public interface IMethod
    {
        string Name { get; set;}
        
        IEnumerable<IParameter> Parameters { get; }

        void AddParameter(IParameter parameter);

        string GetInfo();
    }
}
