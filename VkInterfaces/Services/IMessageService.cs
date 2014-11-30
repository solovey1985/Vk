using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vk.Interfaces.Services
{
    public interface IMessageService : IBaseService
    {
        /// <summary>
        ///  Отправить сообщение
        /// </summary>
        void SendMessage();
        
        /// <summary>
        /// Прочитать все сообщения
        /// </summary>
        void ReadAllMessages();
        
        /// <summary>
        /// Получить все диалоги 
        /// </summary>
        void ReadAllDialogs();
        
        /// <summary>
        /// Читать отдельный диалог
        /// </summary>
        void ReadDialog();

        /// <summary>
        /// Отправить сообщение в диалог
        /// </summary>
        void SendMessageToDialog();

        /// <summary>
        /// Удалить сообщение
        /// </summary>
        void DeleteMessage();

        /// <summary>
        /// Удалить весь диалог
        /// </summary>
        void DeleteDialog();
    }
}
