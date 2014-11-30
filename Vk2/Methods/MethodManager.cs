/* Библиотека методов
 * для формирования запросов
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Vk2.Properties;
using VkInterfaces.V2;


namespace Vk.DTO.Domain
{
    public class VkMethodManager
    {
        private string filePath;
        private XmlDocument xDoc;
        public Dictionary<string, IMethod> methods;

        public VkMethodManager(){
            this.LoadMethods(Directory.GetCurrentDirectory() + Settings.Default.MethodPath);
        } 

        public void LoadMethods(string fileName)
        {
            xDoc = new XmlDocument();

            xDoc.Load(fileName);
            methods = new Dictionary<string, IMethod>();
            this.Parse();
            //return methods;
        }

        /// <summary>
        /// Парсинг с файлом методов
        /// </summary>
        private void Parse(){
            XmlNodeList nodes = xDoc.GetElementsByTagName("method");
            foreach (XmlNode node in nodes){
                methods.Add(node.Attributes["name"].Value, new VkMethod(node.Attributes["name"].Value));
                XmlNodeList parameters = node.SelectNodes("parameters/parameter");

                CreateParameter(node, parameters);
            }
        }
        
        /// <summary>
        /// Создание отдельного параметра по ноду parameter
        /// </summary>
        /// <param name="node"></param>
        /// <param name="Parameters"></param>
        private void CreateParameter(XmlNode node, XmlNodeList parameters)
        {
            string name = "";
            string excludes = "";
            bool required = false;
            string value = "";

            foreach (XmlNode parameter in parameters)
            {
                name = parameter.Attributes["name"].Value;
                if (parameter.Attributes["excludes"] != null)
                    excludes = parameter.Attributes["excludes"].Value;

                if (parameter.Attributes["required"] != null)
                    required = (parameter.Attributes["required"].Value == "true" ? true : false);

                value = parameter.InnerText ?? "";

                methods[node.Attributes["name"].Value].AddParameter(new VkParameter(){Name = name, Excludes = excludes, Required = required, Value = value});
            }
        }

        public IMethod SetMethod(NameValueCollection parameters){

            IMethod method = methods.Values.Single(m => m.Name== parameters["method"]);

            foreach (IParameter parameter in method.Parameters.Where(parameter => parameters.AllKeys.Contains(parameter.Name))){
                parameter.Value = parameters[parameter.Name];
            }
        return method;
        }

        internal string GetMethodInfo(string methodName)
        { 
            StringBuilder info = new StringBuilder();
            try{
                IMethod method = methods.Values.Single(m => m.Name == methodName);
               
                info.AppendLine(method.Name);
                foreach (VkParameter parameter in method.Parameters)
                {
                    info.AppendFormat("Parameter Name: {0}\n", parameter.Name);
                    info.AppendFormat("Required: {0}\n", parameter.Required ? "Yes" : "No");

                    if (!String.IsNullOrEmpty(parameter.Excludes))
                        info.AppendFormat("Excludes: {0}\n", parameter.Excludes);

                    if (!String.IsNullOrEmpty(parameter.Value))
                        info.AppendFormat("Default value: {0}\n", parameter.Value);

                    info.AppendLine();
                }
            }
            catch (Exception){

                info.AppendLine("Метод не найден");
            }
            

            return info.ToString();
        }
    }
}
