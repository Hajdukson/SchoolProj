using System.ComponentModel.DataAnnotations;

namespace SchoolProj.Models
{

    public class Hobby : EntityObject
    {
        [Display(Name = "HobbyType")]
        [RegularExpression(@"^\S[A-Za-z0-9\s]*$", ErrorMessage = "BeginingOfTheString")]
        public HobbyType HobbyType { get; set; }
        [Display(Name = "DayDedicatedTime"), Required(ErrorMessage = "DedicatedTimeError")]
        [Range(0, 24, ErrorMessage = "DedicatedTime")]
        public int TimeSpend { get; set; }
        [Display(Name = "Details")]
        public string Details {get; set; }
    }
    public enum HobbyType
    {
        [Display(Name = "Artistic")]
        Artistic,
        [Display(Name = "Tchnical")]
        Technical,
        [Display(Name = "Recreational")]
        Recreational,
        [Display(Name = "Other")]
        Other
    }
}
