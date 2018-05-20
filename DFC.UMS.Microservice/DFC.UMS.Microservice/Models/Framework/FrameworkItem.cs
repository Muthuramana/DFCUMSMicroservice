using System;
using MongoDB.Bson.Serialization.Attributes;

namespace DFC.UMS.Microservice.Models.Framework
{
    public class FrameworkItem
    {
        [BsonId]
        public Guid Id { get; set; } = new Guid();

        public string Description { get; set; }
    }
}
