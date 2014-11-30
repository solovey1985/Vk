/*
 * Отвечает за представление модели данных в приложении
*/

using System.Collections.Generic;

namespace VkInterfaces.V2
{
    public interface IModel
    {}

    public interface IModelsCollection
    {
        IEnumerable<IModel> ModelsCollection { get; set; }
    }

    public interface IUser: IModel {}

    public interface IMessage: IModel {}

    public interface IPhoto: IModel {}

    public interface IAudio: IModel {}

    public interface IVideo: IModel{}

}
