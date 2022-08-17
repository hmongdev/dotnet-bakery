using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
{
    // All DB fields need both getter and setter
    // id is special, Entity Framework (EF) knows it's a primary key and serial!
    public int id {get; set;} [Required]

    // This is a required database field
    // This makes it NOT NULL in the database,
    // but also automatically sends back 400 errors 
    // if missing in the request body
    public string name {get; set;}
}
}
