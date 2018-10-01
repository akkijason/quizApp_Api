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
    [Route("api/Questions")]
    public class QuestionController: Controller
    {
        readonly QuizContext context;
        public QuestionController(QuizContext context){
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Models.Question> Get(){

            return context.Questions;

            // return new Models.Question[]{
            //     new Models.Question(){text = "hello" },
            //     new Models.Question(){text = "hi" }
            // };

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Question question)
        {
            context.Questions.Add(question); //new Models.Question(){text = "test"}
            await context.SaveChangesAsync();
            return Ok(question);    
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Question questionData)
        {
            //var question = await context.Questions.SingleOrDefaultAsync(q => q.ID == id);
            if(id != questionData.ID)
                return BadRequest();

            context.Entry(questionData).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return Ok(questionData);
        }  
    }
}