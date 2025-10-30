

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using EF_setup.Model;
using Microsoft.Extensions.Logging;
using EF_setup.Model.Entities;
using Azure;


// Data Source=DESKTOP-A58FMDE\SQLEXPRESS;Initial Catalog=Testings;Integrated Security=True;Encrypt=False




using var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging => logging.ClearProviders()) //clears logs
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer("Data Source=DESKTOP-A58FMDE\\SQLEXPRESS;Initial Catalog=NewDB;Integrated Security=True;Encrypt=False")); //connects DbContext to SQL Server 
    })
    .Build();


using var scope = host.Services.CreateScope();

var db = scope.ServiceProvider.GetService<DatabaseContext>();


//Data Seeding
//means we are populating our database with initial data

//db.Database.EnsureCreated();

//db.Database.CanConnect();
//1 server down, 2. database does not exist, 3. connection string is wrong
try
{
    if (!db.Database.CanConnect())
    {
        Console.WriteLine("Database does not exist, creating the database");
        db.Database.Migrate(); //add-migration and update-database
        Console.WriteLine("Database created Successfully");
    }
    else
    {
        Console.WriteLine("Database already exists, updating pending migrations");
        db.Database.Migrate();
        Console.WriteLine("Migrations completed successfully");
    }


    //Any(); returns true if atleast 1 record exists in the table
    if (!db.Grades.Any())
    {
        var grades = new[]
        {
        new Grade {GradeName = "A"},
        new Grade {GradeName = "B"},
        new Grade {GradeName = "C"},
        new Grade {GradeName = "D"},
        new Grade {GradeName = "A"},
        new Grade {GradeName = "F"},
    };

        db.Grades.AddRange(grades); //multiple records
                                    //db.Grades.Add(new Grade { GradeName = "G"}); //one record
        db.SaveChanges();


    }
    else
    {
        Console.WriteLine("Grades already exist");
    }

    if (!db.Students.Any())
    {
        var grades = db.Grades.ToList();
        var students = new[]
        {
        new Student { Name = "Alice Smith", Age = "20", Grade = grades[3] },
        new Student { Name = "Bob Johnson", Age = "21", Grade = grades[1] },
        new Student { Name = "Carol White", Age = "22", Grade = grades[2] },
        new Student { Name = "David Brown", Age = "20", Grade = grades[0] },
        new Student { Name = "Eve Davis", Age = "23", Grade = grades[0] },
    };
        db.Students.AddRange(students); //EF core memory
        db.SaveChanges();

    }
    else
    {
        Console.WriteLine("Students already exist");
    }

    if (!db.Products.Any())
    {
        var products = new[]
        {
        new Product { ProductName = "Laptop", Price = 999.99m, Stock = 10, Category = "Electronics" },
        new Product { ProductName = "Smartphone", Price = 699.99m, Stock = 25, Category = "Electronics" },
        new Product { ProductName = "Desk Chair", Price = 89.99m, Stock = 15, Category = "Furniture" },
        new Product { ProductName = "Bookcase", Price = 129.99m, Stock = 5, Category = "Furniture" },
        new Product { ProductName = "Headphones", Price = 199.99m, Stock = 30, Category = "Electronics" }
    };
        db.Products.AddRange(products);
        db.SaveChanges();
    }
    else
    {
        Console.WriteLine("Products Exist");
    }

    db.Add(new Student { Name = "Elvis Mac", Age = "29", Grade = "E" })
    var aStudents = db.Students.Where(p => p.Grade.GradeName == "A");

    foreach (var student in aStudents)
    {
        Console.WriteLine(student.Name);
    }

    
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
    Console.WriteLine("Check the connection string");
}




















































//using var scope = host.Services.CreateScope(); //DbContext -> DatabaseContext


//var dbservice = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

////dbservice.Database.EnsureCreated();

//if (!dbservice.Database.CanConnect())
//{
//    Console.WriteLine("Database does not exit, creating the database");
//    dbservice.Database.Migrate(); //define the schema, tables, columsn, relationships
//    Console.WriteLine("Database created");
//}
//else
//{
//    Console.WriteLine("Database exists, applying pending migrations");
//    dbservice.Database.Migrate();
//    Console.WriteLine("Migrations Applied Successfully");
//}

////Data seeding 
////means populating your database with inital data

//if (!dbservice.Grades.Any()) //returns true if zero record exists in the table
//{
//    var grades = new[]
//    {
//        new Grade { GradeName = "A" },
//        new Grade { GradeName = "B" },
//        new Grade { GradeName = "C" },
//        new Grade { GradeName = "D" },
//        new Grade { GradeName = "E" },
//        new Grade { GradeName = "F" }
//    };
//    dbservice.AddRange(grades); // EF Core memory 
//    dbservice.SaveChanges();   
//}
//else
//{
//    Console.WriteLine("Grades Already Exist");
//}

//if (!dbservice.Students.Any())
//{
//    var grades = dbservice.Grades.ToList();
//    var students = new[]
//    {
//        new Student { Name = "Alice Smith", Age = "20", Grade = grades[0] },
//        new Student { Name = "Bob Johnson", Age = "21", Grade = grades[1] },
//        new Student { Name = "Carol White", Age = "22", Grade = grades[2] },
//        new Student { Name = "David Brown", Age = "20", Grade = grades[0] },
//        new Student { Name = "Eve Davis", Age = "23", Grade = grades[3] },
//    };
//    dbservice.Students.AddRange(students);
//    dbservice.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Students Already Exist");
//}














//using var scope = host.Services.CreateScope();

//var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();    



//if (!dbContext.Grades.Any())
//{
//    // Add grades
//    var grades = new[]
//    {
//    new Grade { GradeName = "A" },
//    new Grade { GradeName = "B" },
//    new Grade { GradeName = "C" },
//    new Grade { GradeName = "D" },
//    };
//    dbContext.Grades.AddRange(grades);
//    dbContext.SaveChanges();

//}
//else
//{
//    Console.WriteLine("Grades Already Exist");
//}

//if (!dbContext.Students.Any())
//{
//    var grades = dbContext.Grades.ToList();
//    // Add students with assigned Grade_Id (using the added Grade entities)
//    var students = new[]
//    {
//    new Student { Name = "Alice Smith", Age = "20", Grade = grades[0] },
//    new Student { Name = "Bob Johnson", Age = "21", Grade = grades[1] },
//    new Student { Name = "Carol White", Age = "22", Grade = grades[2] },
//    new Student { Name = "David Brown", Age = "20", Grade = grades[0] },
//    new Student { Name = "Eve Davis", Age = "23", Grade = grades[3] },
//    };
//    dbContext.Students.AddRange(students);
//    dbContext.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Students Exist");
//}

//if (!dbContext.Products.Any())
//{
//    IList<Product> products = new List<Product>
//    {
//        new Product { ProductId = 1,
//            ProductName = "Laptop",
//            Price = 999.99m,
//            Stock = 10,
//            Category = "Electronics" },
//        new Product { ProductId = 2,
//            ProductName = "Smartphone",
//            Price = 699.99m,
//            Stock = 25,
//            Category = "Electronics" },
//        new Product { ProductId = 3,
//            ProductName = "Desk Chair",
//            Price = 89.99m,
//            Stock = 15,
//            Category = "Furniture" },
//        new Product { ProductId = 4,
//            ProductName = "Bookcase",
//            Price = 129.99m, Stock = 5,
//            Category = "Furniture" },
//        new Product { ProductId = 5,
//            ProductName = "Headphones",
//            Price = 199.99m, Stock = 30,
//            Category = "Electronics" }
//    };
//}
//else
//{
//    Console.WriteLine("Products Exist");
//}



//Console.WriteLine("Sample data inserted successfully!");





//var studentsWithGrades = dbContext.Students
//    .Include(s => s.Grade)
//    .Where(s => s.Age != null)
//    .OrderBy(s => s.Name)
//    .ToList();


//foreach(var student in studentsWithGrades)
//{
//    Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Grade: {student.Grade?.GradeName ?? "No Grade"}");
//}
//you can setup database anytime and these steps can be mixed
//Once you have database setup, host setup, all files done, THEN do migration

//view -> other windows -> package manager console






//UPLOADING TO GIT!!!!!!!!!!


//Your github repo is created
//to commit changes and push follow this

//this window will always show you changes and give you option to commit and push your files whenever you make any changes

//you can see in your project solution explorer which files have changes made, a red tick mark shows




