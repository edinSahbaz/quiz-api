using Domain.Repositories;
using Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly EnterwellQuizDbContext _context;
    
    public QuizRepository(EnterwellQuizDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Quiz>> GetAllQuizzes()
    {
        return await _context.Quizzes.OrderBy(q => q.AddedTime).ToListAsync();
    }

    public async Task<Quiz> GetQuizById(QuizId quizId)
    {
        return await _context.Quizzes
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(q => q.Id == quizId);
    }

    public async Task<Quiz> CreateQuiz(Quiz toCreate)
    {
        _context.Quizzes.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }
}