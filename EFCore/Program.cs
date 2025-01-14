using EFCore.Data;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

static void CreateDatabase()
{
    using var dbContext = new ShopContext();
    string dbName = dbContext.Database.GetDbConnection().Database;

    var result = dbContext.Database.EnsureCreated();
    if (result ==  true)
        Console.WriteLine($"\nCreate database {dbName} successfully!");
    else
        Console.WriteLine($"\nError create database {dbName}!");
}

static void DropDatabase()
{
    using var dbContext = new ShopContext();
    string dbName = dbContext.Database.GetDbConnection().Database;

    var result = dbContext.Database.EnsureDeleted();
    if (result == true)
        Console.WriteLine($"\nDeleted database {dbName} successfully!");
    else
        Console.WriteLine($"\nError deleted database {dbName}!");
}


CreateDatabase();
//DropDatabase();