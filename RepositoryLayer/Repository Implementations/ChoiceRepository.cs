using RepositoryLayer.Data_Models;
using RepositoryLayer.Database_Context;
using RepositoryLayer.Repository_Interfaces;


namespace RepositoryLayer.Repository_Implementations
{
    public class ChoiceRepository: IChoiceRepository
    {
        private readonly DataContext _context;

        public ChoiceRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public bool AddChoices(Choices choice)
        {
            _context.Choices.Add(choice);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
