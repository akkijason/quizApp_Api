using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace quizApi
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options){ }

        public DbSet<Models.Question> Questions { get; set; }
        
        public DbSet<Models.Quiz> Quizzes { get; set; }
    }
}