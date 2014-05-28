using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vk.DTO.Domain;

namespace ViewModels.Models
{
   public class MessageModel
    {
       public Message Message { get; set; }
       public User User { get; set; }
    }
}
