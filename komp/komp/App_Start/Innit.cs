﻿using System.Web;
using System.Web.Mvc;
using System.IO;
using System;


namespace komp
{
    public class Innit
    {

        public string ConnectionName;
        public string ConnectionPw;
        public string ConnectionHost;


        public void Init(string path)
        {
            
            String line;
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadToEnd();
            }
            ConnectionName = line.Split(';')[0];
            ConnectionPw = line.Split(';')[1];
            ConnectionHost = line.Split(';')[2];


            //var database = "kompiuteriu_komponentai";

            //string connectionString;
            //connectionString = "SERVER=" + ConnectionHost + ";" + "DATABASE=" +
            //database + ";" + "UID=" + ConnectionName+ ";" + "PASSWORD=" + ConnectionPw + ";";

            //new MySqlConnection(connectionString);

        }
    }
}