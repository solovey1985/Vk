using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkInterfaces.V2;
namespace Vk2
{
    public  abstract partial class Controller:IController
    {
        public List<IModel> ModelsCollection { get; set; }
        public List<IViewModel> ViewModelsCollection { get; set; }

    }

    public partial class MessageController : Controller, IMessageController
    {}

    public partial class UserController : Controller, IUserController
    {}

    public partial class AudioController : Controller, IAudioController
    {}

    public partial class PhotoController : Controller, IPhotoController
    { }

}
