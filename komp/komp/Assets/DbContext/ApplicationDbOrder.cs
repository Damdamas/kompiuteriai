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
        public void createOrder(Order order, int userid = -1)
        {
            var comp = new MySqlCompiler();
            var krepselioID = new Query("krepselis").AsMax("id");
            var command1 = new MySqlCommand(comp.Compile(krepselioID).ToString(), connection);
            connection.Open();
            var reader = command1.ExecuteReader();
            var temp = new Order();
            while (reader.Read())
            {
                temp.krepselisId = (int)reader[0];
            }
            connection.Close();
            if (userid > 0)
            {
                userid = -1; // insane programming
            }
            else
            {
                userid = 0;
            }
            var ord = new
            {
                vardas = order.vardas,
                pavarde = order.pavarde,
                elpastas = order.elpastas,
                telnumeris = order.telnumeris,
                adresas = order.adresas,
                data = DateTime.Now.Date,
                atsiemimas = order.atsiemimas,
                mokejimas = order.mokejimas,
                KrepselisId = temp.krepselisId,
                naudotojasId = userid
        };
            var query = new Query("uzsakymas").AsInsert(ord);
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
      
    }
    
}