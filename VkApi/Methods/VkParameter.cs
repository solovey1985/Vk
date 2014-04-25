using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Interfaces.DAL;

namespace Vk.DTO.Domain
{
    public class VkParameter: IParameter
    {

        public string Name { get; set; }

        public string Value { get; set; }

        public bool Required { get; set; }

        public string Excludes { get; set; }

        //Конструктор без параметров
        public VkParameter(){}

        public VkParameter(string name, string excludes, bool required, string value)
        {
            Name = name;
            Excludes = excludes;
            Required = required;
            Value = value;
        }
    }
}
