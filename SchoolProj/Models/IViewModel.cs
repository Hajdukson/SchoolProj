using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SchoolProj.Models
{
    public interface IViewModel<T> where T: EntityObject
    {
        public SelectList ItemsToSelect{ get; set; }
        public string SearchString { get; set; }
        public string SelectedItem { get; set; }
        public List<T> ListOfEntities { get; set; }
    }
}
