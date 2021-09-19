using SchoolProj.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProj.Models
{
    public class Movie : EntityObject
    {
        private const int _classicYear = 1970;
        [Display(Name = "Title"), Required(ErrorMessage = "TitleError")]
        [RegularExpression(@"^\S[A-Za-z0-9\s]*$", ErrorMessage = "BeginingOfTheString")]
        public string Title { get; set; }

        [Display(Name = "ReleaseDate"), Required(ErrorMessage = "ReleasDateError")]

        [ClassicMovie(1970, ErrorMessage = "ClassicMovie")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        [Display(Name = "Price"), Required(ErrorMessage = "PriceError")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }

    public enum Genre
    {
        [Display(Name = "Horror")]
        Horror,
        [Display(Name = "Animated")]
        Animated,
        [Display(Name = "Adventure")]
        Adventure,
        [Display(Name = "Thriller")]
        Thriller,
        [Display(Name = "Classic")]
        Classic
    }
}