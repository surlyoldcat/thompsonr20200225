using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TriangleMan.API.Model;

namespace TriangleMan.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriangleController : ControllerBase
    {
        private const int NUM_COLS = 12;
        private const int NUM_ROWS = 6;

        private readonly ILogger<TriangleController> log;
        private readonly Image image;
        public TriangleController(ILogger<TriangleController> logger)
        {
            log = logger;
            image = new Image(NUM_ROWS, NUM_COLS);
        }

        [HttpGet("bycoords")]
        [Produces("application/json")]
        public IActionResult GetByCoordinates([FromQuery, Required]int x1, [FromQuery, Required]int y1,
            [FromQuery, Required]int x2, [FromQuery, Required]int y2,
            [FromQuery, Required]int x3, [FromQuery, Required]int y3)
        {
            IActionResult response = null;
            var a = new Point(x1, y1);
            var b = new Point(x2, y2);
            var c = new Point(x3, y3);

            try
            {
                var tri = image.FindTriangle(a, b, c);
                response = new OkObjectResult(tri);
            }
            catch (ArgumentException aex)
            {
                response = CreateErrorResult(ApiError.FromException(aex), 400);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                response = CreateErrorResult(ApiError.FromException(ex), 500);
            }
            return response;
        }

        [HttpGet("byrowcol")]
        [Produces("application/json")]
        public IActionResult GetByRowColumn([FromQuery, Required]string row, [FromQuery, Required]int col)
        {
            IActionResult response = null;
            try
            {
                var tri = image.FindTriangle(row, col);
                response = new OkObjectResult(tri);
            }
            catch (ArgumentException aex)
            {
                response = CreateErrorResult(ApiError.FromException(aex), 400);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                response = CreateErrorResult(ApiError.FromException(ex), 500);
            }
            return response;
            
        }

        private static IActionResult CreateErrorResult(ApiError err, int statusCode)
        {
            var res = new ObjectResult(err);
            res.StatusCode = statusCode;
            return res;
        }

        
    }
}
