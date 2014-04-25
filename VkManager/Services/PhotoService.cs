using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using Vk.DTO.Services.Parser;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.Services
{
    class PhotoService: VkService
    {
        public IEnumerable<VkModel> photosgetAll(string uid)
        {
            ClearParameters();
            parameters["method"] = "photos.getAll";
            parameters["owner_id"] = uid;
            parameters["no_services_albums"] = "0";
            
            response = api.RunRequest(parameters);
            ParseAnswer();
            
            return vkObject;
        }

        public override IViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }

        internal override void ParseAnswer()
        {
            parser = new PhotoParser();
            parser.SetResponse(response);
            vkObject = parser.ParseResponse();
        }
    }
}
