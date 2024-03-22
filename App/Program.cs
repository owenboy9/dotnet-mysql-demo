using MySql.Data.MySqlClient;

MySqlConnection db = null;

string connectionString = "server=localhost;uid=root;pwd=mypassword;database=seeSharp;port=3306";

try
{
    db = new MySqlConnection(connectionString);
    db.Open();

    string query = "SELECT * FROM users";
    MySqlCommand command = new(query, db);

    using MySqlDataReader reader = command.ExecuteReader();
    
    while(reader.Read())
    {
        int id = reader.GetInt32("id");
        string username = reader.GetString("username");
        Console.WriteLine($"{username} has the id: {id}");
    }
    
}
catch(MySqlException e)
{
    Console.WriteLine(e);
}
finally
{
    db?.Close();
}