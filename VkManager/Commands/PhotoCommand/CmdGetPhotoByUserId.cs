using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using Vk.DTO.Services;

namespace Vk.DTO.Services.Commands
{
    internal class CmdGetPhotoByUserId : PhotoCommand
    {
        private string _uid;

        public CmdGetPhotoByUserId(string uid)
        {
            _uid = uid;

        }

        public override IEnumerable<VkModel> Execute()
        {
            if (_uid != null && _uid != String.Empty){
                return ((PhotoService) manager).photosgetAll(_uid);

            }
            return null;
        }
    }
}