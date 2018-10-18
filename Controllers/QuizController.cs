using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace quizApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Quizzes")]
    public class QuizController: Controller
    {
        readonly QuizContext context;
        public QuizController(QuizContext context){
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Models.Quiz> Get(){

            return context.Quizzes;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz([FromRoute] int id)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var quiz = await context.Quizzes.SingleOrDefaultAsync(item => item.ID == id);
            if(quiz == null) return NotFound();

            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Quiz quiz)
        {
            context.Quizzes.Add(quiz); //new Models.Question(){text = "test"}
            await context.SaveChangesAsync();
            return Ok(quiz);    
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, [FromBody]Models.Quiz quizData)
        {
            //var question = await context.Questions.SingleOrDefaultAsync(q => q.ID == id);
            if(id != quizData.ID)
                return BadRequest();

            context.Entry(quizData).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return Ok(quizData);
        }  
    }
}