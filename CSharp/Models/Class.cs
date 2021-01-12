using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Class : Entity
    {
        public string Name { get; set; }
        public int Educator_Id { get; set; }
        public Teacher Educator { get; set; }
        public ICollection<Student> Students {get; set;}
    }
}
