using BookLibraryManagementSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookLibraryManagementSystemWebApi.DAL
{
    public class Library
    {
        private readonly string _library = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        public List<Book> GetBooks()
        {
            List<Book> list = new List<Book>();
            using (SqlConnection con = new SqlConnection(_library))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_GetBooks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Book
                    {
                        BookID = Convert.ToInt32(reader["BookID"]),
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Category = reader["Category"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        Publisher = reader["Publisher"].ToString(),
                        PublishedYear = Convert.ToInt32(reader["PublishedYear"]),
                        Language = reader["Language"].ToString(),
                        Pages = Convert.ToInt32(reader["Pages"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        Rating = Convert.ToDecimal(reader["Rating"]),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"])

                    });
                }

            }
            return list;
        }
        public Book GetBookById(int id)
        {
            Book book = new Book();

            using (SqlConnection con = new SqlConnection(_library))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_GetBookById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    book = new Book
                    {
                        BookID = Convert.ToInt32(dr["BookID"]),
                        Title = dr["Title"].ToString(),
                        Author = dr["Author"].ToString(),
                        Category = dr["Category"].ToString(),
                        ISBN = dr["ISBN"].ToString(),
                        Publisher = dr["Publisher"].ToString(),
                        PublishedYear = Convert.ToInt32(dr["PublishedYear"]),
                        Language = dr["Language"].ToString(),
                        Pages = Convert.ToInt32(dr["Pages"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        Rating = Convert.ToDecimal(dr["Rating"]),
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"])
                    };
                }
            }
            return book;
        }
        public bool AddBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_library))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Category", book.Category);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
                cmd.Parameters.AddWithValue("@Language", book.Language);
                cmd.Parameters.AddWithValue("@Pages", book.Pages);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Stock", book.Stock);
                cmd.Parameters.AddWithValue("@Rating", book.Rating);

                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public bool UpdateBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_library))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", book.BookID);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Category", book.Category);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
                cmd.Parameters.AddWithValue("@Language", book.Language);
                cmd.Parameters.AddWithValue("@Pages", book.Pages);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Stock", book.Stock);
                cmd.Parameters.AddWithValue("@Rating", book.Rating);

                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public bool DeleteBook(int id)
        {
            using (SqlConnection con = new SqlConnection(_library))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID",id);

                cmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}