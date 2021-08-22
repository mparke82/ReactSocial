using System;

namespace Domain
{
    public class Activity
    {
        // advantage of Guid is if we create the ID on the client side..
        // we don't have to wait for our DB server to generate the ID and send it back, we can do it all inside the client
        // Entity framework will recognize Id as a primary key - because of the name Id
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}