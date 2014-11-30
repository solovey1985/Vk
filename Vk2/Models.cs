using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkInterfaces.V2;

namespace Vk2
{
    public abstract partial class Model: IModel
    {}

    public partial class User: Model, IUser{}

    public partial class Message : Model, IMessage { }

    public partial class Photo : Model, IPhoto { }

    public partial class Audio : Model, IAudio { }

    public partial class Video : Model, IVideo { }


}
