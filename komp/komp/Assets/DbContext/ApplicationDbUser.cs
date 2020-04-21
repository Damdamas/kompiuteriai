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

namespace komp
{
    class ApplicationDbUser
    {
       MySqlConnection connection;  public ApplicationDbUser()
        {

            var conn = new InnitConnectionStrings();
            conn.Init();
            
            var database = "komiuteriu_komponentai";

            string connectionString;
            connectionString = "SERVER=" + conn.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + conn.ConnectionName + ";" + "PASSWORD=" + conn.ConnectionPw + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void CreateUser(naudotojas acc)
        {
            var comp = new MySqlCompiler();
            acc.role = "registruotas naudotojas";
            var query = new Query("naudotojas").AsInsert(acc);
     
            
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
        public naudotojas GetUser(naudotojas acc)
        {
            naudotojas ieskomas = new naudotojas();

            var comp = new MySqlCompiler();


            var query = new Query("naudotojas").Where("slaptazodis", acc.slaptazodis).Where("elpastas", acc.elpastas);
            var cc = comp.Compile(query).ToString();
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                ieskomas.vardas = reader["vardas"].ToString();
                ieskomas.pavarde = reader["pavarde"].ToString();
                ieskomas.elpastas = reader["elpastas"].ToString();
                ieskomas.prisijungimoVardas = reader["prisijungimoVardas"].ToString();
                ieskomas.slaptazodis = reader["slaptazodis"].ToString();
                ieskomas.telnumeris = reader["telnumeris"].ToString();
                ieskomas.adresas = reader["adresas"].ToString();
                ieskomas.role = reader["role"].ToString();
                ieskomas.id = (int)reader["id"];               
            }
            connection.Close();

            return ieskomas;
        }
        public bool EmailExists(naudotojas acc)
        {
            var comp = new MySqlCompiler();
            var query = new Query("naudotojas").Where("elpastas", acc.elpastas);
            var cc = comp.Compile(query).ToString();
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
            
            
        }
        public bool NameExists(naudotojas acc)
        {
            var comp = new MySqlCompiler();
            var query = new Query("naudotojas").Where("PrisijungimoVardas", acc.prisijungimoVardas); ;
            var cc = comp.Compile(query).ToString();
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
    }
}