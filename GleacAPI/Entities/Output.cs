using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GleacAPI.Entities
{
    public class Output
    {
        public List<char> HorizontalHeaders { get; set; }
        public List<char> VerticalHeaders { get; set; }

        public List<List<int>> Cells { get; set; }

        public Output()
        {
            HorizontalHeaders = new List<char>();
            VerticalHeaders = new List<char>();
            Cells = new List<List<int>>();
        }
    }
}
