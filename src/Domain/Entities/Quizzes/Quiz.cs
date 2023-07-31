﻿using System.Text.Json.Serialization;
using Domain.Entities.Questions;
using Domain.Primitives;

namespace Domain.Entities.Quizzes;

public sealed class Quiz : Entity
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    
    [JsonIgnore]
    public ICollection<Question> Questions { get; set; }
}