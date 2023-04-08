using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoScrap.Models
{
    public class PartSystemViewModel
    {
        public List<Part>? Parts { get; set; }
        public SelectList? Systems { get; set; }
        public string? PatrtSystem { get; set; }
        public string? SearchString { get; set; }
    }
}
