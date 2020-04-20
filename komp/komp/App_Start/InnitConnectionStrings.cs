using System.Web;
using System.Web.Mvc;
using System.IO;
using System;


namespace komp
{
    public class InnitConnectionStrings
    {

        public string ConnectionName;
        public string ConnectionPw;
        public string ConnectionHost;


        public void Init()
        {
            string path = HttpContext.Current.Server.MapPath("~/Assets/constants/connections.txt");
            String line;
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadToEnd();
            }
            ConnectionName = line.Split(';')[0];
            ConnectionPw = line.Split(';')[1];
            ConnectionHost = line.Split(';')[2];
        }
    }
}
