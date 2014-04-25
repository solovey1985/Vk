using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.Interfaces.Domain;

namespace Vk.DTO.Services.Commands
{

     class PhotoCommand: VkCommand
     {
         internal List<IPhoto> photoList;

         internal PhotoCommand()
         {
             photoList = new List<IPhoto>();
             manager = new PhotoService();
         }
     }
}
