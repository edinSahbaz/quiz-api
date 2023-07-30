using Domain.Entities.Questions;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly EnterwellQuizDbContext _context;
    
    public QuestionRepository(EnterwellQuizDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Question>> GetAllQuestions()
    {
        return await _context.Questions.OrderBy(q => q.Prompt).ToListAsync();
    }

    public async Task<Question> CreateQuestion(Question toCreate)
    {
        _context.Questions.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task<Question> UpdateQuestion(QuestionId questionId, string prompt, string answer)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == questionId);

        question.Prompt = prompt;
        question.Answer = answer;

        await _context.SaveChangesAsync();
        
        return question;
    }

    public async Task DeleteQuestion(QuestionId questionId)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == questionId);
        
        if(question is null) return;

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }
}