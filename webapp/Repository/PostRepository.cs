using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

public class PostRepository
{
    private string connectionString;

    public PostRepository()
    {
        connectionString = @"Server=localhost;Database=TotalSolution;Trusted_Connection=true";
    }

    public IDbConnection Connection 
    {
        get {
            return new SqlConnection(connectionString);
        }
    }


    public void Add(Post post)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "INSERT INTO Posts (title, body)"
                            + " VALUES(@title, @body)";

            dbConnection.Open();
            dbConnection.Execute(query, post);
        }
    }

    public IEnumerable<Post> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<Post>("SELECT * FROM Posts");
        }
    }


    public Post GetByID(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "SELECT * FROM Posts"
                            + " WHERE id = @id";
            dbConnection.Open();
            return dbConnection.Query<Post>(query, new { id = id }).FirstOrDefault();
        }
    }

    public void Delete(int id)
    {
        using ( IDbConnection dbConnection = Connection)
        {
            string query = "DELETE FROM Posts"
                            + " WHERE id = @id";
                        
            dbConnection.Open();
            dbConnection.Execute(query, new { id = id });
        }
    }

    public void Update(Post post)
    {
        using ( IDbConnection dbConnection = Connection)
        {
            string query = "UPDATE Posts SET title = @title,"
                            + " body = @body"
                            + " WHERE id = @id";

            dbConnection.Open();
            dbConnection.Query(query, post);
        }
    }
}