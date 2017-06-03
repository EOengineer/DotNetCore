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
        connectionString = @"Server=localhost;Database=TotalSolution;User Id=SA;Password=<YourStrong!Passw0rd>";
    }

    public IDbConnection Connection 
    {
        get {
            return new SqlConnection(connectionString);
        }
    }



    public IEnumerable<Post> Index()
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<Post>("SELECT * FROM Posts");
        }
    }


    public Post Details(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "SELECT * FROM Posts"
                            + " WHERE id = @id";
            dbConnection.Open();
            return dbConnection.Query<Post>(query, new { id = id }).FirstOrDefault();
        }
    }



    public void Create(Post post)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "INSERT INTO Posts (title, body, created_at, updated_at)"
                            + " VALUES(@title, @body, GETDATE(), GETDATE())";

            dbConnection.Open();
            dbConnection.Execute(query, post);
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

}