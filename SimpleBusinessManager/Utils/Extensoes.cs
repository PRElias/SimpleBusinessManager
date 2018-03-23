using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBusinessManager.Utils
{
    public static class Extensoes
    {
        public static MvcHtmlString TelephoneLink(this HtmlHelper htmlHelper, string telephoneNumber)
        {
            var tb = new TagBuilder("a");
            tb.Attributes.Add("href", string.Format("tel:+{0}", telephoneNumber));
            tb.SetInnerText(telephoneNumber);
            return new MvcHtmlString(tb.ToString());
        }

        public static MvcHtmlString TrataMeses(this HtmlHelper htmlHelper, int mes)
        {
            string mesnome = "";
            switch (mes)
            {
                case 1:
                    mesnome = "Janeiro";
                    break;
                case 2:
                    mesnome = "Fevereiro";
                    break;
                case 3:
                    mesnome = "Março";
                    break;
                case 4:
                    mesnome = "Abril";
                    break;
                case 5:
                    mesnome = "Maio";
                    break;
                case 6:
                    mesnome = "Junho";
                    break;
                case 7:
                    mesnome = "Julho";
                    break;
                case 8:
                    mesnome = "Agosto";
                    break;
                case 9:
                    mesnome = "Setembro";
                    break;
                case 10:
                    mesnome = "Outubro";
                    break;
                case 11:
                    mesnome = "Novembro";
                    break;
                case 12:
                    mesnome = "Dezembro";
                    break;
            }
            return new MvcHtmlString(mesnome);
        }
    }
}