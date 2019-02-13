using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using QuizRestController.Data;
using QuizRestController.Data.Entities;

namespace QuizRestController.Services
{
    public class QuizServices : IQuizServices
    {
        private readonly QuizContext _context;

        public QuizServices(QuizContext context)
        {
            this._context = context;
        }

        public IEnumerable<Quiz> GetAllQuizElements()
        {
            return _context.Quizes
                .Include(quiz => quiz.Questions)
                .ThenInclude(question => question.Answers)
                .ToList();
        }

        public Quiz CreateQuiz(Quiz quiz)
        {
            _context.Add(quiz);
            _context.SaveChanges();
            return quiz;
        }

        public Quiz DeleteQuiz(int quizId)
        {
            var x = _context.Quizes.Include(q => q.Questions)
                    .ThenInclude(a => a.Answers)
                    .SingleOrDefault(i => i.Id == quizId);
            _context.Remove(x);
            _context.SaveChanges();
            return x;
        }

        public Quiz RenameQuiz(int quizId, string newName)
        {
            var x = _context.Quizes.Include(q => q.Questions)
                    .ThenInclude(a => a.Answers)
                    .SingleOrDefault(i => i.Id == quizId); 
            x.Title = newName;
            _context.Update(x);
            _context.SaveChanges();

            return x;
        }

        public Quiz AddQuestion(int quizId, Question question)
        {
            var x = _context.Quizes.Include(q => q.Questions)
                                        .ThenInclude( a => a.Answers)
                                            .SingleOrDefault(i => i.Id == quizId);
            x.Questions.Add(question);
            _context.Quizes.Update(x);
            _context.SaveChanges();

            return x;
        }

        public Question DeleteQuestion(int quizId, int questionId)
        {
            var x = _context.Quizes.Include(q => q.Questions)
                    .ThenInclude(a => a.Answers)
                    .SingleOrDefault(i => i.Id == quizId);
            var y = x.Questions.SingleOrDefault(j => j.Id == questionId);
            _context.Questions.Remove(y);
            _context.SaveChanges();

            return y;
        }
    }
}
