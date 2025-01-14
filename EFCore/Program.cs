using EFCore.Data;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

static void CreateDatabase()
{
    using var dbContext = new ShopContext();
    string dbName = dbContext.Database.GetDbConnection().Database;

    var result = dbContext.Database.EnsureCreated();
    if (result ==  true)
        Console.WriteLine($"\nCreate database {dbName} successfully!\n");
    else
        Console.WriteLine($"\nError create database {dbName}!\n");
}

static void DropDatabase()
{
    using var dbContext = new ShopContext();
    string dbName = dbContext.Database.GetDbConnection().Database;

    var result = dbContext.Database.EnsureDeleted();
    if (result == true)
        Console.WriteLine($"\nDeleted database {dbName} successfully!\n");
    else
        Console.WriteLine($"\nError deleted database {dbName}!\n");
}

static void InsertData()
{
    using var dbContext = new ShopContext();
    Category category1 = new Category() { Name = "Điện thoại", Description = "Các loại điện thoại" };
    Category category2 = new Category() { Name = "Đồ uống", Description = "Các loại đồ uống"};

    dbContext.Categories.Add(category1);
    dbContext.Categories.Add(category2);

    Product product1 = new Product() { Name = "IPhone", Price = 1000, CategoryId = 1 };
    Product product2 = new Product() { Name = "Samsung", Price = 2000, CategoryId = 1 };
    Product product3 = new Product() { Name = "Rượu vang", Price = 5000, CategoryId = 1 };
    Product product4 = new Product() { Name = "Nokia", Price = 9000, CategoryId = 1 };
    Product product5 = new Product() { Name = "Cafe", Price = 1000, CategoryId = 2 };
    Product product6 = new Product() { Name = "Trà Thảo Mộc", Price = 5000, CategoryId = 2 };

    dbContext.SaveChanges();
}


//DropDatabase();
//CreateDatabase();
InsertData();