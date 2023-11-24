using Application_Layer.DTO;
using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IRequestExamSevice
    {
        ResponseExamDto RequestExam(int subjectId, string studentId);
    }
}
