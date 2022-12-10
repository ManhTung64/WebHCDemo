using System.Collections.Generic;

namespace ProjectWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
