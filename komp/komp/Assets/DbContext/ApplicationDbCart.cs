using System;
using System.Collections.Generic;
using System.Linq;
using SqlKata;
using SqlKata.Compilers;
using MySql.Data.MySqlClient;
using System.Web;
using komp.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

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
<<<<<<< HEAD
        public void createCart(Cart cart, int userid = -1)
=======
        public void createCart(Cart cart, int useridr = -1)
>>>>>>> e80ab15b22eb49c3152c9d913a00cc8c02e8bf74
        {
            var comp = new MySqlCompiler();
            var query = new Query("krepselis").AsInsert(cart);

            var command = new MySqlCommand("INSERT INTO krepselis (pavadinimas, sukurimoData, patvirtintas, naudotojasId) VALUES" +
                " ('',@text1, @text2, @text3)", connection);
            command.Parameters.AddWithValue("@text1", cart.sukurimoData);
            command.Parameters.AddWithValue("@text2", cart.patvirtintas);
            if(userid > 0)
            {
                command.Parameters.AddWithValue("@text3", userid);
            }
            else
            {
                command.Parameters.AddWithValue("@text3", 0);
            }
           

            connection.Open();
            command.ExecuteReader();
            connection.Close();
            addItemsToCart(cart);
        }
        public void addItemsToCart(Cart cart)
        {
            var comp = new MySqlCompiler();
            var query = new Query("krepselis").AsMax("id");
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            var reader = command.ExecuteReader();
            var temp = new Cart();
            while (reader.Read())
            {
                temp.id = (int)reader[0];
            }
            connection.Close();
            for (int i = 0; i<cart.prekes.Count;i++)
            {
                connection.Open();
                var obj = new
                {
                    krepselisId = temp.id,
                    prekeId = cart.prekes[i].id
                };
                var q = new Query("KrepselisPreke").AsInsert(obj);
                var command1 = new MySqlCommand(comp.Compile(q).ToString(), connection);
                command1.ExecuteNonQuery();
                connection.Close();
            }
            
        }
        public void updateCart(Cart cart)
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