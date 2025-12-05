using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibraryManagementSystemWebApi.Models
{
    public class Book
    {
        public int BookID {  get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        [Required,StringLength(100)]
        public string Author {  get; set; }
        [Required,StringLength(50)]
        public string Category {  get; set; }
        [Required,StringLength(20)]
        public string ISBN {  get; set; }
        [StringLength(100)]
        public string Publisher {  get; set; }
        [Required]
        public int PublishedYear {  get; set; }
        [StringLength(100)]
        public string Language {  get; set; }
        [Range(1, 5000)]
        public int Pages { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Range(0, 1000)]
        public int Stock { get; set; }

        [Range(0, 5)]
        public decimal Rating { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}