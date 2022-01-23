using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FileInfoApp
{
    class File
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Creator { get; set; }

        private static string myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        private const string SelectQuery = "Select * from File_details";
        private const string InsertQuery = "Insert Into File_details(Id, Title, Name, CreationTime, Creator) Values (@Id, @Title, @Name, @Time, @Creator)";
        private const string UpdateQuery = "Update File_details set Id=@Id, Title=@Title, Name=@Name, CreationTime=@Time where Creator=@Creator";
        private const string DeleteQuery = "Delete from File_details where Id=@Id";


        public DataTable GetFile()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public bool Add(File file)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@Id", file.Id);
                    com.Parameters.AddWithValue("@Title", file.Title);
                    com.Parameters.AddWithValue("@Name", file.Name);
                    com.Parameters.AddWithValue("@CreationTime", file.Time.ToString());
                    com.Parameters.AddWithValue("@Creator", file.Creator);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public bool Update(File file)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@Id", file.Id);
                    com.Parameters.AddWithValue("@Title", file.Title);
                    com.Parameters.AddWithValue("@Name", file.Name);
                    com.Parameters.AddWithValue("@CreationTime", file.Time.ToString());
                    com.Parameters.AddWithValue("@Creator", file.Creator);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public bool Delete(File file)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@Id", file.Id);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

    }
}
    