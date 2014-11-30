/* Инкапсулирует запрос к API
 * Содержит настраиваемае параметры
 * для гибкого изменения запроса всеми 
 * уровнями приложения.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkInterfaces.V2
{
    public interface IMethod
    {
        string Name { get; set; }
        List<IParameter> Parameters { get; set; }
    }

    public interface IParameter
    {
        string Name { get; set; }

        string Value { get; set; }

        bool Required { get; set; }

        string Excludes { get; set; }
    }
}
