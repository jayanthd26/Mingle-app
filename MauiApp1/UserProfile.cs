using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MauiApp1;

public class UserProfile
{
    public ObjectId Id { get; set; }
    public string MobileNumber { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public DateTime DateOfBirth { get; set; }

    [BsonElement("Friends")]
    public List<string> Friends { get; set; } = new List<string>();
}