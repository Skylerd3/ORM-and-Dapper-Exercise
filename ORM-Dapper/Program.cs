
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;

static void Main(string[] args)
{
    
}

    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    
    string connString = config.GetConnectionString("DefaultConnection");
    
    IDbConnection conn = new MySqlConnection(connString);

    var repo = new DapperProductRepository(connection: conn);

    Console.WriteLine("What is the name of your product");
    var ProdName = Console.ReadLine();
    Console.WriteLine("What is the price of your product");
    var ProdPrice = double.Parse(Console.ReadLine());
    Console.WriteLine("What is the catigoryID of your product");
    var ProdCatigoryID = int.Parse(Console.ReadLine());
    
    repo.CreatProducts(ProdName, ProdPrice, ProdCatigoryID);

    var Products = repo.GetAllProducts();
    foreach (var prod in Products)
    {
        Console.WriteLine($" {prod.ProductID}, {prod.Name}");

    }
    
   










