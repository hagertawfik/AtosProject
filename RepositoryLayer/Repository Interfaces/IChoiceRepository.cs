using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Interfaces
{
    public interface IChoiceRepository
    {
        bool AddChoices(Choices choice);
        bool Save();
    }
}
