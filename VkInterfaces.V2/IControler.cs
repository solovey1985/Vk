/*  Контроллеры отвечают за подготовку и отправку запросов Сервисам, 
 * а также получение от них доменных моделей и формирование на их основе
 * Моделей Представления, и предоставления своих методов для команд в Моделях
 * Представления. В общем, ответственные за двусторонее обновления данных 
 * от API и пользовательского интерфейса. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkInterfaces.V2
{
    public interface IController
    {
        List<IModel>  ModelsCollection { get; set; }
        List<IViewModel>  ViewModelsCollection { get; set; }

    }

    public interface IMessageController:IController{}
    public interface IUserController : IController{}
    public interface IPhotoController: IController{}
    public interface IAudioController:IController{}
}
