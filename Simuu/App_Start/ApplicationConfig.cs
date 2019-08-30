using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simuu
{
    public class ApplicationConfig
    {

        public static void RegisterAplicationVariables()
        {
            string pageSizeString = System.Configuration.ConfigurationManager.AppSettings["DefaultPageSize"];
            int DefaultPageSize = 0;
            bool parsable = int.TryParse(pageSizeString, out DefaultPageSize);
            if (!parsable)
            {
                DefaultPageSize = 3;
            }
            HttpContext.Current.Application["DefaultPageSize"] = DefaultPageSize;
        }


        public static int DefaultPageSize
        {
            get
            {
                return (int)HttpContext.Current.Application["DefaultPageSize"];
            }
        }

    }
}