/* Библиотека авторизации
 *  для VKontakte
 *  25/12/2013
*/
//TODO: Добавть загрузку параметров из прикрепленных к библиотеке конфигов

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using log4net;

[Flags]
public enum VkScopeList
{
    /// <summary>
    ///     Пользователь разрешил отправлять ему уведомления.
    /// </summary>
    notify = 1,

    /// <summary>
    ///     Доступ к друзьям.
    /// </summary>
    friends = 2,

    /// <summary>
    ///     Доступ к фотографиям.
    /// </summary>
    photos = 4,

    /// <summary>
    ///     Доступ к аудиозаписям.
    /// </summary>
    audio = 8,

    /// <summary>
    ///     Доступ к видеозаписям.
    /// </summary>
    video = 16,

    /// <summary>
    ///     Доступ к предложениям (устаревшие методы).
    /// </summary>
    offers = 32,

    /// <summary>
    ///     Доступ к вопросам (устаревшие методы).
    /// </summary>
    questions = 64,

    /// <summary>
    ///     Доступ к wiki-страницам.
    /// </summary>
    pages = 128,

    /// <summary>
    ///     Добавление ссылки на приложение в меню слева.
    /// </summary>
    link = 256,

    /// <summary>
    ///     Доступ заметкам пользователя.
    /// </summary>
    notes = 2048,

    /// <summary>
    ///     (для Standalone-приложений) Доступ к расширенным методам работы с сообщениями.
    /// </summary>
    messages = 4096,

    /// <summary>
    ///     Доступ к обычным и расширенным методам работы со стеной.
    /// </summary>
    wall = 8192,

    /// <summary>
    ///     Доступ к документам пользователя.
    /// </summary>
    docs = 131072
}

namespace Vk.DTO.Auth
{
    
    public partial class VkAuthManager
    {
    //    public readonly ILog log = LogManager.GetLogger(typeof (VkAuthManager));
        private string error = String.Empty;
        private string message = String.Empty;
        private VkScopeList scope;
        private int intScope;
        private readonly ILog log = LogManager.GetLogger(typeof (VkAuthManager));

        public string Login {  get; set; }

        public string Pass {  get; set; }

        private HttpWebRequest request;
        private HttpWebResponse response;
        private StreamReader reader;
        private CookieContainer cookieContainer;

        public VkAuthManager()
        {
            SetScope(VkScopeList.messages | VkScopeList.friends | VkScopeList.notify | VkScopeList.photos);
            LoadSettings(TryTologin:true);
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Загрузка менеджера авторизации");
        }

        public VkAuthManager(string login, string pass):this(){
            this.Login = login;
            this.Pass = pass;
            SetScope(VkScopeList.messages | VkScopeList.friends | VkScopeList.notify);
            LoadSettings(true);
        }

        public void SetScope(VkScopeList scope)
        {
            if ((int) scope < 1) this.scope = VkScopeList.notify | VkScopeList.friends;

            this.intScope = (int) scope;
        }

        /// <summary>
        ///     Формирование запроса на авторизацию,
        ///     который передается в браузер
        /// </summary>
        /// <returns></returns>
        public string GetAuthRequest()
        {
            string appId = ConfigurationSettings.AppSettings.Get("appId");
            string authUrl = ConfigurationSettings.AppSettings.Get("AuthUrl");
            string redirectUrl = ConfigurationSettings.AppSettings.Get("Redirect URL");
            ;
            string scope = intScope.ToString();
            string responseType = ConfigurationSettings.AppSettings.Get("response_type");
            string display = ConfigurationSettings.AppSettings.Get("display");
            
            string request = String.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}&display={4}&response_type={5}",
                authUrl,
                appId,
                redirectUrl,
                scope,
                display,
                responseType);

            return request;
        }

        public void GetRealAuth(string login, string pass)
        {
             this.Login = login;
             this.Pass = pass;

            /* Порядок аворизации
             * 1. Получить форму для ввода логина и пароля
             * 2. Распарсить: получить поля логина, пароля и URL action'a 
             * 3. Сформировать и отправить запрос via POST
             * 4. Получить ответ и сохранить куки
             * 5. На основании Header["Location"] запрос формы подтверждения прав приложения
             * 6. Отправка запроса via GET
             * 7. Получение отвтеа и получение URL action'а формирование запроса и отправка via POST
             * 8. Получение ответа и поиск access_token либо в Header["Location"] либо в ResponseURI (время от времени он меняет положение)
             * 9. Запись параметров в VkAuthInfo и сохранение настроек.
             */

            if (!String.IsNullOrEmpty(this.Login) || !String.IsNullOrEmpty(this.Pass)){
                string HTML = GetAuthForm();
                //TODO: private string GetAuthForm();


                bool isLoginFormLoaded = IsLoginFormLoaded(HTML);


                if (isLoginFormLoaded){
                    //Получение набора значений для  авторизации
                    var qs = new NameValueCollection();
                    ParseLoginForm(HTML, out qs);

                    // Отправка данных для авторизации
                    SendAuthorizeRequest(qs);

                    //Подтверждение прав приложения
                    GrantAccess(HTML);

                    //получение Access Token, Expires, User id
                    GetAccessToken();
                }
                log.Info("Сохранение настроек");
                SaveSettings();
            }
        }

        

        public string GetErrorMessage()
        {
            return error;
        }

        public string GetMessage()
        {
            return message;
        }

        public void LoadSettings(bool TryTologin){
            if (!IsExpired()){
                VkAuthInfo.AccessToken = Properties.Settings.Default.accessToken;
                VkAuthInfo.UserId = Properties.Settings.Default.userId;
                VkAuthInfo.ExpiresIn = Properties.Settings.Default.expiresIn;
            }
            else{
                
                if (TryTologin)
                {GetRealAuth(Login, Pass); log.Info("Токен просрочен. Попытка авторизироваться");}
            }
        }

        public void SaveSettings(){
            if (!String.IsNullOrEmpty(VkAuthInfo.AccessToken)){
                Properties.Settings.Default.accessToken = VkAuthInfo.AccessToken;
                SetExpiredTime(VkAuthInfo.ExpiresIn);
                Properties.Settings.Default.userId = VkAuthInfo.UserId;
                Properties.Settings.Default.Save();
            }
            else{
              log.Error("Сбой при сохрененнии настроек. Токен пустой");
            }
        }

        public void ResetSettings(){
            
            Properties.Settings.Default.accessToken = String.Empty;
                Properties.Settings.Default.expiresIn = String.Empty;
                    Properties.Settings.Default.userId = String.Empty;
        
            Properties.Settings.Default.Save();
        }

        private void SetExpiredTime(string expires_in)
        {
            var time = new DateTime();
            time = DateTime.Now;
            time = time.AddSeconds(Double.Parse(expires_in));
            Properties.Settings.Default.expiresIn = time.ToString();
            
        }

        public bool IsExpired()
        {
            //Проверка: access_token непустой ли
            if (!String.IsNullOrEmpty(Properties.Settings.Default.accessToken)){
                //Проверка: expiresIn непустой
                if (!String.IsNullOrEmpty(Properties.Settings.Default.expiresIn)){
                    
                    string expires = Properties.Settings.Default.expiresIn;
                    var time = new DateTime();
                    time = DateTime.Now;
                    int result = DateTime.Compare(time, DateTime.Parse(expires).Subtract(new TimeSpan(1, 0, 0)));
                        
                    if (result < 0) //Текущее время раньше чем указаное в настройках
                            return false;
               }
            }
            return true;
        }
    }

    /// <summary>
    /// Partial класс с методами для авторизации и разбора отвтетов
    /// </summary>
    public partial class VkAuthManager
    {
        /// <summary>
        /// Отправка запроса для получения формы авторизации
        /// </summary>
        /// <returns></returns>
        private string GetAuthForm()
        {
            log.Info("Получение формы авторизации");

            string requestString = string.Empty;
            requestString = GetAuthRequest();
            request = (HttpWebRequest)WebRequest.Create(requestString);
            response = (HttpWebResponse)request.GetResponse();

            reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string HTML = reader.ReadToEnd();
            return HTML;
        }

        private bool IsLoginFormLoaded(string form_html)
        {
            //Проверка правильности формы
            string strRegex = @"<form (?<form_body>.*)</form>";

            var myRegex = new Regex(strRegex,
                RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            foreach (Match myMatch in myRegex.Matches(form_html))
            {
                if (myMatch.Success)
                {
                    log.Info("Форма авторизации загружена");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Парсинг формы авторизации
        /// </summary>
        /// <param name="HTML">HTML формы</param>
        /// <param name="qs">Значения полей формы</param>
        private void ParseLoginForm(string HTML, out NameValueCollection qs)
        {
            Regex myRegex =
                                    new Regex(
                                        "<input(.*?)name=\"(?<name>[^\x22]+)\"(.*?)((value=\"(?<value>[^\x22]*)\"(.*?))|(.?))>",
                                        RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

            qs = new NameValueCollection();
            foreach (Match m in myRegex.Matches(HTML))
            {
                string val = m.Groups["value"].Value;
                if (m.Groups["name"].Value == "email") 
                    val = this.Login;
                else 
                    if (m.Groups["name"].Value == "pass") 
                        val = this.Pass;
                qs.Add(m.Groups["name"].Value, HttpUtility.UrlEncode(val));
            }
        }

        /// <summary>
        /// Отправка запроса на авторизацию
        /// </summary>
        /// <param name="qs">Значения полей из формы</param>
        private void SendAuthorizeRequest(NameValueCollection qs)
        {
            byte[] b =
                Encoding.UTF8.GetBytes(String.Join("&",
                    from item in qs.AllKeys select item + "=" + qs[item]));

            request = (HttpWebRequest)WebRequest.Create("https://login.vk.com/?act=login&soft=1&utf8=1");
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = b.Length;
            request.GetRequestStream().Write(b, 0, b.Length);
            request.AllowAutoRedirect = false;
            log.Info("Получение результата запроса авторизации");
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string HTML = reader.ReadToEnd();
            cookieContainer = new CookieContainer();
            foreach (Cookie c in response.Cookies)
            {
                cookieContainer.Add(c);
            }
        }

        /// <summary>
        /// Отправка формы с подтверждениями прав доступа приложения 
        /// к данным пользователя
        /// </summary>
        /// <param name="HTML">Код получений после отправки формы авторизации</param>
        private void GrantAccess(string HTML)
        {
            log.Info("Подтверждение прав авторизации");

            //TODO private void GrantAccess()
            if (!String.IsNullOrEmpty(response.Headers["Location"]))
            {
                // делаем редирект
                request = (HttpWebRequest)WebRequest.Create(response.Headers["Location"]);
                request.CookieContainer = cookieContainer; // передаем куки
                request.Method = "GET";
                request.ContentType = "text/html";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                HTML = reader.ReadToEnd();
            }
            else
            {
                log.Error("Ошибка отправки запроса прав приложения. Неверныйй Location.");
                error = "Ошибка. Ожидался редирект.";

            }
            Regex myRegex =
                        new Regex("Вы авторизованы как <b><a href=\"(?<url>[^\\x22]+)\">(?<user>[^\\x3c]+)</a></b>",
                            RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

            log.Info(String.Format("Авторизация успешно прошла.\nПользователь {0}",
                myRegex.Match(HTML).Groups["user"].Value));
            message = String.Format("Авторизация успешно прошла.\nПользователь {0}",
                myRegex.Match(HTML).Groups["user"].Value);
            myRegex = new Regex("<form(.*?)action=\"(?<post_url>[^\\x22]+)\"(.*?)>(?<form_body>.*?)</form>",
                RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

            if (!myRegex.IsMatch(HTML))
                log.Error("Не удалось получить форму. Проверьте шаблон регулярного выражения.");
            error = "Не удалось получить форму. Проверьте шаблон регулярного выражения.";
            string url = myRegex.Match(HTML).Groups["post_url"].Value;
            if (!url.ToLower().StartsWith("https://")) url = String.Format("https://api.vk.com{0}", url);

            request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookieContainer; // не забываем передавать куки
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;
            request.AllowAutoRedirect = false;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                log.Error("Ошибка при получении формы подтверждения прав");
                error = "Ошибка при получении формы подтверждения прав";
            }
        }

        /// <summary>
        /// Парсинг ответа и получение Access Token, UserID, время жизни токена
        /// </summary>
        private void GetAccessToken()
        {
            string strToParse = !String.IsNullOrEmpty(response.Headers["Location"])
                ? response.Headers["Location"]
                : response.ResponseUri.AbsoluteUri;
            if (!String.IsNullOrEmpty(strToParse))
            {
                Regex myRegex = new Regex(@"((?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+))",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myRegex.Matches(strToParse))
                {
                    switch (m.Groups["name"].Value)
                    {
                        case "access_token":
                            {
                                VkAuthInfo.AccessToken = m.Groups["value"].Value;
                                break;
                            }
                        case "user_id":
                            {
                                VkAuthInfo.UserId = m.Groups["value"].Value;
                                break;
                            }
                        case "expires_in":
                            {
                                VkAuthInfo.ExpiresIn = m.Groups["expires_in"].Value == ""
                                    ? "86400"
                                    : m.Groups["expires_in"].Value;
                                break;
                            }
                        default:
                            {
                                VkAuthInfo.ExpiresIn = "86400";
                                break;
                            }
                    }
                }
                log.Info("Авторизация прошла успешно. Access_token: " + VkAuthInfo.AccessToken);
                message = String.Format("Ключ доступа: {0}\nUserID: {1}", VkAuthInfo.AccessToken, VkAuthInfo.UserId);
            }

        }
    }
}