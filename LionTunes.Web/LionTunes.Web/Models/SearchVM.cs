using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionTunes.Web.Models
{
    /// <summary>
    /// Bings search results to a ViewModel class that can be used for passing data between views and controllers.
    /// </summary>
    public class SearchVM
    {
        public string SearchType { get; set; }
        public string SearchText { get; set; }
   
    }
}
