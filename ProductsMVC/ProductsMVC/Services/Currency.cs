using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace ProductsMVC.Services
{
    public class Currency
    {

         public string CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
        {
            
            WebClient web = new WebClient();
            string url = string.Format("https://www.google.com/finance/converter?a", fromCurrency.ToUpper(), toCurrency.ToUpper(), amount);
            string response = web.DownloadString(url);
            Regex regex = new Regex(@":(?<rhs>.+?),");
            string[] arrDigits = regex.Split(response);
            string rate = arrDigits[3];
            return rate;
        }
    


    }
}