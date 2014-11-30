using VkInterfaces.V2;

namespace Vk2
{
    public abstract partial class Service:IService
    {}

    public partial class MessageService: Service, IMessageService{}

    public partial class UserService : Service, IUserService {}

    public partial class PhotoService : Service, IPhotoService {}

    public partial class AudioService : Service, IAudioService {}

    public partial class VideoService : Service, IVideoService {}
 }
