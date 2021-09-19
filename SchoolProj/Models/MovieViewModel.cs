using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolProj.Models
{
    public class MovieViewModel : IViewModel<Movie>
    {
        public SelectList ItemsToSelect { get; set; }
        public string SearchString { get; set; }
        public string SelectedItem { get; set; }
        public List<Movie> ListOfEntities { get; set; }
    }
}
