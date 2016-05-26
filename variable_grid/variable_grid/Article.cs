using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variable_grid
{
    public class Article
    {
        public string Name { get; set; } // title of artice
        public string image { get; set; } //Image associated with article
        public string description { get; set; } //Article description 
        public int ColSpan { get; set; }
        public int RowSpan { get; set; }
        public int Type { get; set; }
    }

   
}
