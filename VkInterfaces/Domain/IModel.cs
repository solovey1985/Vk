using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Interfaces.Domain
{
    public interface IModel
    {
        int Id { get; set; }
    }

    public interface IModelCollection
    {
        IEnumerable<IModel> ModelCollection { get; set; }
    }

    public interface IMessage:IModel
    {}

    public interface IPhoto: IModel{}

    public interface IUser: IModel{}
}
