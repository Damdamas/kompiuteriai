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

namespace komp
{
    class ApplicationDbUser
    {
       MySqlConnection connection;
        public ApplicationDbUser()
        {

            var conn = new InnitConnectionStrings();
            conn.Init();
            
            var database = "komiuteriu_komponenta";

            string connectionString;
            connectionString = "SERVER=" + conn.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + conn.ConnectionName + ";" + "PASSWORD=" + conn.ConnectionPw + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void UpdateUser(User acc, string pw = null)
        {
            var comp = new MySqlCompiler();
            object c;
            if(!(pw is null))
            c = new 
            {
                vardas = acc.vardas,
                pavarde = acc.pavarde,
                elpastas = acc.elpastas,
                prisijungimoVardas = acc.prisijungimoVardas,
                slaptazodis = acc.slaptazodis,
                telnumeris = acc.telnumeris,
                adresas = acc.adresas
            };
            else
                c = new
                {
                    vardas = acc.vardas,
                    pavarde = acc.pavarde,
                    elpastas = acc.elpastas,
                    prisijungimoVardas = acc.prisijungimoVardas,
                    telnumeris = acc.telnumeris,
                    adresas = acc.adresas
                };
            var query = new Query("naudotojas").Where("Id", acc.id).AsUpdate(c);
            var str = comp.Compile(query).Sql;
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
        public void CreateUser(User acc)
        {
            var comp = new MySqlCompiler();
            acc.role = Role.User;
            var query = new Query("naudotojas").AsInsert(acc);
     
            
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
        public User GetUserById(int id)
        {
            User ieskomas = new User();

            var comp = new MySqlCompiler();


            var query = new Query("naudotojas").Where("id", id);
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
        public User GetUser(User acc)
        {
            User ieskomas = new User();

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
        public bool EmailExists(User acc)
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
        public bool NameExists(User acc)
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