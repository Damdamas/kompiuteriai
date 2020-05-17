using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlKata;
using SqlKata.Compilers;
using komp.Models;

namespace komp.Assets.DbContext
{

    public class ApplicationDbOrder
    {
        readonly MySqlConnection connection;

        public ApplicationDbOrder()
        {
            var conn = new InnitConnectionStrings();
            conn.Init();

            var database = "komiuteriu_komponenta";

            string connectionString;
            connectionString = "SERVER=" + conn.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + conn.ConnectionName + ";" + "PASSWORD=" + conn.ConnectionPw + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void createOrder(Order order)
        {
            var comp = new MySqlCompiler();
            var query = new Query("užsakymas").AsInsert(order);


            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
      
    }
    
}