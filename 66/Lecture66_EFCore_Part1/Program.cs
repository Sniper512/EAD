﻿using Lecture66_EFCore_Part1;
using System;
using System.Linq;

Console.WriteLine("EF Core");

Product p = new Product();
p.Name = "Bike";
p.Price = 45;

var db = new MyShopContext();
db.Products.Add(p);

await db.SaveChangesAsync();

Console.WriteLine($"product added with id = {p.ID}");

//read

db.Products.Where(p => p.Name.StartsWith("B")).ToList()
    .ForEach(p => Console.WriteLine($"{p.Name} : {p.Price} : {p.ID}"));

Console.WriteLine("updating product");

var p2 = db.Products.First();
p2.Price = 90;
await db.SaveChangesAsync();

var p3 = db.Products.First(p=>p.Price<90);
db.Remove(p3);
await db.SaveChangesAsync();