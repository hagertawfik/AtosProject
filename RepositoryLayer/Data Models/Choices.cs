using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class Choices
    {
        [Key]
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
