using SchoolProj.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolProj.Attributes
{
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
}
