using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Program
    {
        private static string _connectionString = @"Server=.\SQLEXPRESS;Database=BooksDB;Trusted_Connection=True";
        static void Main(string[] args)
        {

            //CreateTable();
            //EditBooks();
            //AddBooks();
            //AddBooksBySP();
            //EditAuthors();
            //AddAuthors();
            AddAuthorsBySP();

            Console.ReadLine();
        }

        private static void AddAuthorsBySP()
        {
            Console.WriteLine("Add First Name");
            var firstName = Console.ReadLine();
            Console.WriteLine("Add Last Name");
            var lastName = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddAuthor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(@"FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add(@"LastName", SqlDbType.NVarChar).Value = lastName;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddAuthors()
        {
            Console.WriteLine("Add First Name");
            var firstName = Console.ReadLine();
            Console.WriteLine("Add Last Name");
            var lastName = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"Insert into Author (FirstName,LastName) values ('" + firstName + "','" + lastName + "')";
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }

        private static void EditAuthors()
        {
            Console.WriteLine("Enter Id for author");
            string insertId = "";
            bool isNumber = true;
            do
            {
                insertId = Console.ReadLine();
                isNumber = int.TryParse(insertId, out int number);
                if (!isNumber)
                {
                    Console.WriteLine("You must enter number for AuthorId!!Enter AuthorId");
                }
            }
            while (!isNumber);
            string queryEditAuthor = @"Update Author set 
                                FirstName=@FirstName,
                                LastName=@LastName
                                where AuthorId=@AuthorId";
            Console.WriteLine("Edit FirstName");
            string firstNameEdit = Console.ReadLine();
            Console.WriteLine("Edit LastName");
            string lastNameEdit = Console.ReadLine();
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryEditAuthor, connection);
                cmd.Parameters.AddWithValue("@AuthorId", insertId);
                cmd.Parameters.AddWithValue("@FirstName", firstNameEdit);
                cmd.Parameters.AddWithValue("@LastName", lastNameEdit);
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddBooksBySP()
        {
            Console.WriteLine("Add Title");
            var title = Console.ReadLine();
            Console.WriteLine("Add Genre");
            var genre = Console.ReadLine();
            bool isNumber = true;
            string authorId = "";
            Console.WriteLine("Add AuthorId");
            do
            {
                authorId = Console.ReadLine();
                isNumber = int.TryParse(authorId, out int number);
                if (!isNumber)
                {
                    Console.WriteLine("You must enter number for AuthorId!!Add AuthorId");
                }
            }
            while (!isNumber);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(@"Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add(@"Genre", SqlDbType.NVarChar).Value = genre;
                cmd.Parameters.Add(@"AuthorId", SqlDbType.Int).Value = authorId;
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }

        private static void AddBooks()
        {
            Console.WriteLine("Add Title");
            var title = Console.ReadLine();
            Console.WriteLine("Add Genre");
            var genre = Console.ReadLine();
            bool isNumber = true;
            string authorId = "";
            Console.WriteLine("Add AuthorId");
            do
            {
                authorId = Console.ReadLine();
                isNumber = int.TryParse(authorId, out int number);
                if (!isNumber)
                {
                    Console.WriteLine("You must enter number for AuthorId!!Add AuthorId");
                }
            }
            while (!isNumber);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"Insert into Book (Title,Genre,AuthorId) values ('" + title + "','" + genre + "','" + authorId + "')";
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void EditBooks()
        {
            Console.WriteLine("Enter Id for book");
            string insertId = Console.ReadLine();
            int insertID = Int32.Parse(insertId);
            string queryEditBook = @"Update Book set 
                                Title=@Title,
                                Genre=@Genre,
                                AuthorId=@AuthorId
                                where BookId=@BookId";
            Console.WriteLine("Edit Title");
            string titleEdit = Console.ReadLine();
            Console.WriteLine("Edit Genre");
            string genreEdit = Console.ReadLine();
            Console.WriteLine("Edit AuthorId");
            var authorId = Console.ReadLine();
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryEditBook, connection);
                cmd.Parameters.AddWithValue("@BookId", insertID);
                cmd.Parameters.AddWithValue("@Title", titleEdit);
                cmd.Parameters.AddWithValue("@Genre", genreEdit);
                cmd.Parameters.AddWithValue("@AuthorId", authorId);
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }

        private static void CreateTable()
        {
            string queryAuthor = @"Create table dbo.Author
                ( AuthorId int IDENTITY(1,1) not null,
                  FirstName nvarchar(50) null,
                  LastName nvarchar(50) null)";
            string queryBooks = @"Create table dbo.Book
                ( BookId int IDENTITY(1,1) not null,
                  Title nvarchar(50) null,
                  Genre nvarchar(50) null,
                   AuthorId int not null)";
            string queryBookSP = @"Create procedure sp_AddBook 
                    (@Title nvarchar(50) null,
                     @Genre nvarchar(50) null,
                     @AuthorId int null)
                     as
                       insert into Book(Title,Genre,AuthorId) values (@Title,@Genre,@AuthorId)";
            string queryAuthorSP = @"Create procedure sp_AddAuthor 
                    (@FirstName nvarchar(50) null,
                     @LastName nvarchar(50) null)
                     as
                       insert into Author(FirstName,LastName) values (@FirstName,@LastName)";
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmdA = new SqlCommand(queryAuthor, connection);
                SqlCommand cmdB = new SqlCommand(queryBooks, connection);
                SqlCommand cmdBSp = new SqlCommand(queryBookSP, connection);
                SqlCommand cmdASp = new SqlCommand(queryAuthorSP, connection);
                connection.Open();
                cmdA.ExecuteNonQuery();
                cmdB.ExecuteNonQuery();
                cmdBSp.ExecuteNonQuery();
                cmdASp.ExecuteNonQuery();
            }
        }
    }
}
