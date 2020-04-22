using System;
using System.Collections.Generic;
using System.Linq;
using SqlKata;
using SqlKata.Compilers;
using MySql.Data.MySqlClient;
using System.Web;
using komp.Models;

namespace komp.Assets.DbContext
{
    public class ApplicationDbComment
    {
        readonly MySqlConnection connection;

        public ApplicationDbComment()
        {
            var conn = new InnitConnectionStrings();
            conn.Init();

            var database = "komiuteriu_komponentai";

            string connectionString;
            connectionString = "SERVER=" + conn.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + conn.ConnectionName + ";" + "PASSWORD=" + conn.ConnectionPw + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void CreateComment(Comment comment)
        {
            var comp = new MySqlCompiler();
            var query = new Query("komentaras").AsInsert(comment);


            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
    }
}