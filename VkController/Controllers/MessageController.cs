using System.Threading;
using System.Threading.Tasks;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.Controllers
{
    public class MessageController: VkController
    {
        public MessageController(){
            _service = ServiceFactory.GetService<IMessageService>();
        }

        public IViewModel Bind()
        {
            Task<IViewModel> t = Task.Run(() =>
            {
                return _service.GetViewModel();
            });
            return t.Result;
        }
    }
}
