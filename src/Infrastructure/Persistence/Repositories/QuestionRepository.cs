using Domain.Entities.Questions;
using Domain.Entities.Quizzes;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly EnterwellQuizDbContext _context;
    
    public QuestionRepository(EnterwellQuizDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Question>> GetAllQuestions()
    {
        return await _context.Questions.OrderBy(q => q.AddedTime).ToListAsync();
    }

    public async Task<ICollection<Question>> GetQuizQuestions(QuizId quizId)
    {
        return await _context.Questions
            .Where(q => q.Quizzes.Any(quiz => quiz.Id == quizId))
            .OrderBy(q => q.AddedTime)
            .ToListAsync();
    }

    public async Task<ICollection<Question>> GetQuestionsByIds(ICollection<QuestionId> questions)
    {
        return await _context.Questions
            .Where(q => questions.Contains(q.Id))
            .OrderBy(q => q.AddedTime)
            .ToListAsync();
    }

    public async Task<ICollection<Question>> GetQuestionByPrompt(string prompt)
    {
        return await _context.Questions
            .Where(q => q.Prompt.ToLower().Contains(prompt.ToLower()))
            .OrderBy(q => q.AddedTime)
            .ToListAsync();
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

        if (question is null) throw new QuestionNotFoundException();
        
        question.Prompt = prompt;
        question.Answer = answer;
        question.LastModified = DateTime.Now;

        await _context.SaveChangesAsync();
        
        return question;
    }

    public async Task DeleteQuestion(QuestionId questionId)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == questionId);
        
        if(question is null) throw new QuestionNotFoundException();

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }
}