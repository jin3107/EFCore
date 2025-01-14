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
        Console.WriteLine($"Create database {dbName} successfully!");
    else
        Console.WriteLine($"Error create database {dbName}!");
}

static void DropDatabase()
{
    using var dbContext = new ShopContext();
    string dbName = dbContext.Database.GetDbConnection().Database;

    var result = dbContext.Database.EnsureDeleted();
    if (result == true)
        Console.WriteLine($"Deleted database {dbName} successfully!");
    else
        Console.WriteLine($"Error deleted database {dbName}!");
}

static void InsertProduct()
{
    /*
     - Model (Product)
     - Add, AddAsync
     - SaveChanges, SaveChangesAsync
    */
    using var dbContext = new ShopContext();
    //var p1 = new Product();
    //p1.Name = "San pham 1";
    //p1.Provider = "Cong ty 1";

    //var p2 = new Product()
    //{
    //    Name = "San pham 2",
    //    Provider = "Cong ty 2",
    //};

    var products = new object[]
    {
        new Product() { Id = 1, Name = "San pham 1", Provider = "CTY A" },
        new Product() { Id = 2,Name = "San pham 2", Provider = "CTY B" },
        new Product() { Id = 3,Name = "San pham 3", Provider = "CTY C" },
        new Product() { Id = 4,Name = "San pham 4", Provider = "CTY D" },
        new Product() { Id = 5,Name = "San pham 5", Provider = "CTY E" },
    };

    //dbContext.Add(products);
    dbContext.AddRange(products);
    int row = dbContext.SaveChanges();
    Console.WriteLine($"{row} row product created.");
}

static void ReadProduct()
{
    using var dbContext = new ShopContext();
    // Linq
    // Cách 1
    //var products = dbContext.Products.ToList();
    //products.ForEach(product => product.PrintInfo());

    // Cách 2
    //var query = from product in dbContext.Products
    //            where product.Id >= 3
    //            select product;
    //query.ToList().ForEach(product => product.PrintInfo());

    //Cách 3
    //var products = dbContext.Products.Where(product => product.Id >= 3)
    //    .ToList();

    /* 
     * Truy vấn cột Provider với điều kiện có chuỗi là `Cong ty` bằng `Contains()` method.
     * Giảm dần theo Id sản phẩm bằng `OrderByDescending()` method.
    */ 
    var products = dbContext.Products.Where(product => product.Provider.Contains("Cong ty"))
        .OrderByDescending(product => product.Id).ToList();
    if (products.Count == 0)
        Console.WriteLine("Product in Database was null.");
    else
        products.ForEach(product => product.PrintInfo());
}

static void UpdateProduct(int id, string newName, string newProvider)
{
    using var dbContext = new ShopContext();
    var product = dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
    if (product == null)
        Console.WriteLine("Product in Database was null");
    else
    {
        product.Name = newName;
        product.Provider = newProvider;
        int row = dbContext.SaveChanges();
        Console.WriteLine($"{row} Product updated successfully.");
    }
}

static void DeleteProduct(int id)
{
    using var dbContext = new ShopContext();
    var product = dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
    if (product == null)
        Console.WriteLine("Product in Database was null.");
    else
    {
        dbContext.Products.Remove(product);
        int row = dbContext.SaveChanges();
        Console.WriteLine($"{row} row product deleted.");
    }
}


//CreateDatabase();
DropDatabase();

// Insert, Select, Update, Delete
//InsertProduct();
//ReadProduct();
//UpdateProduct(6, "San pham 1", "Cong ty 1");
//DeleteProduct(6);