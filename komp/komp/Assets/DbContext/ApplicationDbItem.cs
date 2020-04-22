using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;
using komp.Models;
using komp.Models.tipai;

namespace komp.Assets.DbContext
{
    public class ApplicationDbItem
    {
        readonly MySqlConnection connection;
        public ApplicationDbItem()
        {

            var conn = new InnitConnectionStrings();
            conn.Init();

            var database = "komiuteriu_komponentai";

            string connectionString;
            connectionString = "SERVER=" + conn.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + conn.ConnectionName + ";" + "PASSWORD=" + conn.ConnectionPw + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void CreateItem(Item item)
        {
            var comp = new MySqlCompiler();
            var query = new Query("preke").AsInsert(item);


            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

    }
}