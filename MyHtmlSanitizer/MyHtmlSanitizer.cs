using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHtmlSanitizer
{
    /// <summary>
    /// 使用时，注意将app.config中的配置copy到引用的程序中。
    /// </summary>
    public class MyHtmlSanitizer
    {
        public static Dictionary<string, object> Filter(Dictionary<string, object> dic)
        {
            Dictionary<string, object> infoListCopy = new Dictionary<string, object>();
            var htmlSan = new Ganss.XSS.HtmlSanitizer();
            foreach (var item in dic.Keys)
            {
                infoListCopy.Add(item, htmlSan.Sanitize(dic[item].ToString()));
            }
            return infoListCopy;
        }

        public static string Sanitize(string content)
        {
            return new Ganss.XSS.HtmlSanitizer().Sanitize(content);
        }
    }
}
