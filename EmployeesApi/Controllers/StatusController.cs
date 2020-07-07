using EmployeesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class StatusController : ControllerBase
    {
        ISystemTime Time;

        public StatusController(ISystemTime time)
        {
            Time = time;
        }

        //GET /status 
        [HttpGet("status")]
        [Produces("application/json")]
        public ActionResult<StatusResponse>GetStatus()
        {
            // 1. TODO Go cehck the actual status
            var response = new StatusResponse
            {
                Status = "I'm giving it all I got, Captain!",
                CheckedBy = "Scottie",
                LastChecked = Time.GetCurrent().AddMinutes(-15)
            };
            return Ok(response);
        }
        // 1. Route Params
        /// <summary>
        /// <response code ="200">Worked</response>
        /// <response code ="400">Didn't Work</response>
        [HttpGet("books/{bookId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetABook(int bookId)
        {
            return Ok($"Getting you info for a book {bookId}");
        }

        [HttpGet("blogs/{year:int}/{month:int:range(1,12)}/{date:int}")]
        public ActionResult GetBlogPostsFor(int year, int month, int day)
        {
            return Ok($"Getting blog posts for {month}/{day}/{year}");
        }

        // 2. Query Strings
        [HttpGet("books")]
        public ActionResult GetBooks([FromQuery] string genre = "All")
        {
            return Ok($"Getting you books in the {genre} genre");
        }

        // 3. Briefly Headers
        [HttpGet("whoami")]
        public ActionResult WhoAmI([FromHeader(Name = "User-Agent")] string userAgent)
        {

            return Ok($"OK I see you are running {userAgent}");
        }
        // 4. Entities
        [HttpPost("games")]
        //when it calls the method it creates an instance of game
        // It deserialize the game. then it runs the validation attributes
        // and uses the result to produce ModelState
        public ActionResult AddGame([FromBody] PostGameRequest game) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok($"Adding {game.Title} for {game.Platform} for {game.Price:c}");
            }
        }
        public class PostGameRequest
        {
            [Required]
            [StringLength(50, ErrorMessage ="That name is too long!")]
            public string Title { get; set; }
            [Required]
            public string Platform { get; set; }
            [Required]
            public decimal? Price { get; set; }

        }
        public class StatusResponse
        {
            public string Status { get; set; }
            public string CheckedBy { get; set; }
            public DateTime LastChecked { get; set; }
        }
    }   
}
