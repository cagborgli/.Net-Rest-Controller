using Microsoft.AspNetCore.Mvc;
using QuizRestController.Data.Entities;
using QuizRestController.Services;
using System.Collections.Generic;

namespace QuizRestController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private IQuizServices _quizServices;

        public QuizController(IQuizServices quizServices)
        {
            _quizServices = quizServices;
        }

        //GET AllQuizElements -  api/quiz
        [HttpGet]
        public ActionResult<IEnumerable<Quiz>> Get()
        {
            return Ok(_quizServices.GetAllQuizElements());
        }

        //POST quiz-  api/
        [HttpPost]
        public ActionResult<Quiz> CreateQuiz([FromBody] Quiz quiz)
        {
            return Ok(_quizServices.CreateQuiz(quiz));
        }

        //DELETE quiz -  api/quizId
        [HttpDelete ("{quizId}")]
        public ActionResult<Quiz> DeleteQuiz(int quizId)
        {
            return Ok(_quizServices.DeleteQuiz(quizId));
        }

        //PATCH Rename Quiz -- api/quiz/{quizId}/rename/{newName}
        [HttpPatch ("{quizId}/rename/{newName}")]
        public ActionResult<Quiz> RenameQuiz(int quizId, string newName)
        {
            return Ok(_quizServices.RenameQuiz(quizId, newName));
        }

        //PATCH Adds Question -- api/quiz/{quizId}/add
        [HttpPatch("{quizId}/add")]
        public ActionResult<Quiz> AddQuestion(int quizId, [FromBody] Question question)
        {
            return Ok(_quizServices.AddQuestion(quizId,question));
        }

        //DELETE Question -- api/quiz/{quizId}/add
        [HttpDelete("{quizId}/delete/{questionId}")]
        public ActionResult<Question> DeleteQuestion(int quizId,int questionId)
        {
            return Ok(_quizServices.DeleteQuestion(quizId, questionId));
        }      

    }
}
