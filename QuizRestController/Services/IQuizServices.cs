using QuizRestController.Data.Entities;
using System.Collections.Generic;

namespace QuizRestController.Services
{
    public interface IQuizServices
    {
        IEnumerable<Quiz> GetAllQuizElements();
        Quiz CreateQuiz(Quiz quiz);
        Quiz DeleteQuiz(int quizId);
        Quiz RenameQuiz(int quizId, string newName);
        Quiz AddQuestion(int quizId, Question question);
        Question DeleteQuestion(int quizId, int questionId);
    }
}
