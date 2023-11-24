using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class SubjectRequestDto
    {
        [MinLength(4, ErrorMessage = "minimum length 4")]
        public string Name { get; set; }
    }
}
