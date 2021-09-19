using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SchoolProj.Models
{
    public class HobbyViewModel : IViewModel<Hobby>
    {
        public SelectList ItemsToSelect { get; set; }
        public string SearchString { get; set; }
        public string SelectedItem { get; set; }
        public List<Hobby> ListOfEntities { get; set; }
    }
}
