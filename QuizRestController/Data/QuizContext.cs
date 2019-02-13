using Microsoft.EntityFrameworkCore;
using QuizRestController.Data.Entities;

namespace QuizRestController.Data
{
    public class QuizContext :DbContext
    {
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizContext(DbContextOptions<QuizContext> options): base(options)
        {
        }
    }
}
