using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            VideoIdsAndNames = new List<KeyValuePair<string, string>>();
            MaterialIdsAndNames = new List<KeyValuePair<string, string>>();
        }
        public string DisciplineName { get; set; }
        public string Grade { get; set; }

        public List<KeyValuePair<string, string>> VideoIdsAndNames { get; set; }
        public List<KeyValuePair<string, string>> MaterialIdsAndNames { get; set; }
    }
}
