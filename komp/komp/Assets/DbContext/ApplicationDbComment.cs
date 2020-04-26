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
        public void CreateComment(Comment comment, int userid, int itemid)
        {
            comment.naudotojasId = userid;
            comment.prekeId = itemid;
            comment.turinys = @comment.turinys;
            var comp = new MySqlCompiler();
            var query = new Query("komentaras").AsInsert(comment);

            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();


            command.ExecuteNonQuery();
            connection.Close();
        }

        public IList<Comment> SelectCommentsByItem(int itemID)
        {
            var comments = new List<Comment>();
            var comp = new MySqlCompiler();
            var query = new Query("komentaras").Where("prekeId",itemID);
            var command = new MySqlCommand(comp.Compile(query).ToString(), connection);
            connection.Open();


            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var comment = new Comment();
                comment.id = (int)reader["id"];
                comment.sukurimoData = (DateTime) reader["sukurimoData"];
                comment.turinys = reader["turinys"].ToString();
                comments.Add(comment);
            }
            connection.Close();
            return comments;
        }
    }
}