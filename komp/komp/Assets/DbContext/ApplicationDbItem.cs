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
        public void CreateItem(Item item, string path)
        {
            var comp = new MySqlCompiler();
            var c = new
            {
                pavadinimas = item.pavadinimas,
                kaina = item.kaina,
                aprasymas = item.aprasymas,
                tipas = item.tipas,
                reitingas = item.reitingas,
                imagePath = path,
                matomas = item.matomas
            };
            var query = new Query("preke").AsInsert(c);


            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
        public IList<Item> GetItems(int count)
        {
            
            IList<Item> ieskomasArr = new List<Item>();

            var comp = new MySqlCompiler();


            var query = new Query("preke").Limit(count);
            var cc = comp.Compile(query).ToString();
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item ieskomas = new Item();
                ieskomas.pavadinimas = reader["pavadinimas"].ToString();
                ieskomas.tipas = reader["tipas"].ToString();
                ieskomas.path = reader["imagePath"].ToString();
                ieskomas.kaina = (float)reader["kaina"];
                ieskomas.matomas = (bool)reader["matomas"];
                ieskomas.reitingas = (float)reader["reitingas"];
                ieskomas.aprasymas = reader["aprasymas"].ToString();
                ieskomas.id = (int)reader["id"];
                ieskomasArr.Add(ieskomas);
            }
            connection.Close();

            return ieskomasArr;
        }
        public Item GetItemById(int id)
        {
            var comp = new MySqlCompiler();
            Item ieskomas = new Item();

            var query = new Query("preke").Where("id", id);
            var cc = comp.Compile(query).ToString();
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                ieskomas.pavadinimas = reader["pavadinimas"].ToString();
                ieskomas.tipas = reader["tipas"].ToString();
                ieskomas.path = reader["imagePath"].ToString();
                ieskomas.kaina = (float)reader["kaina"];
                ieskomas.matomas = (bool)reader["matomas"];
                ieskomas.reitingas = (float)reader["reitingas"];
                ieskomas.aprasymas = reader["aprasymas"].ToString();
                ieskomas.id = (int)reader["id"];
            }

            return ieskomas;
        }

    }
}