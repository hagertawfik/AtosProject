using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class StudentDto
    {
     
        public string Id { get; set; }
       
        public string Stname { get; set; }
       
        public string Email { get; set; }
       
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
