using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Course : ICourseBase
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Credits { get; set; } = default!;
        public ClassDescription Description { get; set; } = default!;
        public ICollection<Schedule> ScheduleEntrys { get; set; } = new List<Schedule>();
    }
}
