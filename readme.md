## First school project for programming subject

It's a simply website created with ASP .Net Core MVC.

# Features

- Users can create, read, update and delete items from database
- The application is localized in English and Polish languages

# Issues

Isue with localization of the ErrorMessage in the ClassicMovieAttribute class:

```C#
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }
        public int Year { get; }
        public string GetErrorMessage() => $"{FormatErrorMessage(ErrorMessageString)} {Year}";
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if (movie.Genre == Genre.Classic && releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
```

Movie model class

```C#
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
```

It never dispales a value from a resources. It always shows ClassicMovie.
