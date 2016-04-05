using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PathValidator
{
    /// <summary>
    /// Summary description for Checker
    /// </summary>
    public class Checker : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string path = "";
            if (null == context.Request.Params["filePath"])
                return;
            path = context.Request.Params["filePath"];

            if (Directory.Exists(path))
            {
                return;
            }
            else
            {
                int lastExtIndex = 0;
                lastExtIndex = path.LastIndexOf(".");
                if (lastExtIndex > 0)
                {
                    int lastSlashIndex = 0;
                    lastSlashIndex = path.LastIndexOf("\\");
                    path = path.Substring(0, lastSlashIndex);
                }
                Directory.CreateDirectory(path);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}