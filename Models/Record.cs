using System;

namespace ProjectWeb.Models
{
    public class Record
    {
        public int id { get; set; }
        public string document_name { get; set; }
        public string document_id { get; set; }
        public DateTime signed_day { get; set; }
        public string book_number { get; set;}
        public string version { get; set;}
        public int last_fix { get; set; }
        public string tag { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Dear_to { get; set; }
        public string Destination { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
