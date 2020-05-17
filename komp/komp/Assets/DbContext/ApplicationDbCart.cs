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
    public class ApplicationDbCart
    {
        readonly MySqlConnection connection;

        public ApplicationDbCart()
        {
            var conn = new InnitConnectionStrings();
            conn.Init();

            var database = "komiuteriu_komponenta";

            string connectionString;
            connectionString = "SERVER=" + conn.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + conn.ConnectionName + ";" + "PASSWORD=" + conn.ConnectionPw + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void createCart(Basket cart)
        {
            var comp = new MySqlCompiler();
            var query = new Query("krepšelis").AsInsert(cart);


            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
        public void updateCart(Basket cart)
        {
            var comp = new MySqlCompiler();
            object temp;

            temp = new
            {
                pavadinimas = cart.pavadinimas,
                sukurimoData = cart.sukurimoData,
                patvirtintas = cart.patvirtintas,
                prekes = cart.prekes
            };
            var query = new Query("krepšelis").Where("Id", cart.id).AsUpdate(temp);
            var str = comp.Compile(query).Sql;
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();

        }
    
    }
}