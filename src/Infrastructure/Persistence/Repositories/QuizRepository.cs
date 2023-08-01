using Domain.Entities.Questions;
using Domain.Repositories;
using Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly EnterwellQuizDbContext _context;
    private readonly IQuestionRepository _questionRepository;
    
    public QuizRepository(EnterwellQuizDbContext context, IQuestionRepository questionRepository)
    {
        _context = context;
        _questionRepository = questionRepository;
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
        toCreate.AddedTime = DateTime.Now;
        toCreate.LastModified = DateTime.Now;
        
        _context.Quizzes.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task<Quiz> UpdateQuiz(QuizId quizId, string title, ICollection<QuestionId> questionIds)
    {
        var quiz = _context.Quizzes
            .Include(q => q.Questions)
            .FirstOrDefault(q => q.Id == quizId);

        var questions = await _questionRepository.GetQuestionsByIds(questionIds);
        
        quiz.Title = title;
        quiz.LastModified = DateTime.Now;

        quiz.Questions.Clear();
        quiz.Questions = questions;

        await _context.SaveChangesAsync();
        
        return quiz;
    }

    public async Task DeleteQuiz(QuizId quizId)
    {
        var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == quizId);
        
        if(quiz is null) return;

        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();
    }
}