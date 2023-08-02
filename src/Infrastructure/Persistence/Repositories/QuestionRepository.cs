using System.Linq.Expressions;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Entities.Quizzes;
using Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly EnterwellQuizDbContext _context;
    
    public QuestionRepository(EnterwellQuizDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Question>> GetAllQuestions(string? sortColumn, string? sortOrder, int page, int pageSize, string? prompt)
    {
        IQueryable<Question> questionsQuery = _context.Questions;

        if (!string.IsNullOrEmpty(prompt))
        {
            questionsQuery = questionsQuery.Where(q => q.Prompt.ToLower().Contains(prompt.ToLower()));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            questionsQuery = questionsQuery.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            questionsQuery = questionsQuery.OrderBy(GetSortProperty(sortColumn));
        }

        var questions = await questionsQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return questions;
    }

    private static Expression<Func<Question, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "prompt" => question => question.Prompt,
            "answer" => question => question.Answer,
            _ => question => question.AddedTime
        };
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