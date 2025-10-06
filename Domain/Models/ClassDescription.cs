using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ClassDescription
    {
        public string Area = default!;
        public string Clave = default!;
        public string TheoryHours = default!;
        public string PracticeHours = default!;
        public string Type = default!;
        public string AcademicLevel = default!;
        public bool HasExtraordinario;
        public ICollection<string> prerequisitos = new List<string>();
        public ICollection<string> corequisite = new List<string>();
        public ICollection<string> departments = new List<string>();
        public ICollection<string> careers = new List<string>();
        public ICollection<string> campus = new List<string>();
    }
}
