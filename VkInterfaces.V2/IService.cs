/* Сервисы отвечают за подготовку и отправку запросов к API,
 * а также получение ответа, его парсинг и формирование доменных 
 * моделей данных
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkInterfaces.V2
{
    public interface IService  {}

    public interface IMessageService : IService{}
    public interface IUserService : IService {}
    public interface IPhotoService : IService {}
    public interface IAudioService : IService {}
    public interface IVideoService : IService{}




}
