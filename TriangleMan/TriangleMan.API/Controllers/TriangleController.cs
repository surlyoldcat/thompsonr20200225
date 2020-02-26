using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TriangleMan.API.Model;
using TriangleMan.API.Services;

namespace TriangleMan.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriangleController : ControllerBase
    {
        private const int NUM_COLS = 12;
        private const int NUM_ROWS = 6;

        private readonly ILogger<TriangleController> log;
        private readonly IImageService imageSvc;
        public TriangleController(ILogger<TriangleController> logger,
            IImageService imgSvc)
        {
            log = logger;
            imageSvc = imgSvc;
        }

        [HttpGet("bycoords")]
        [Produces("application/json")]
        public IActionResult GetByCoordinates([FromQuery, Required]int x1, [FromQuery, Required]int y1,
            [FromQuery, Required]int x2, [FromQuery, Required]int y2,
            [FromQuery, Required]int x3, [FromQuery, Required]int y3)
        {
            IActionResult response = null;
            try
            {
                var tri = imageSvc.FindTriangle(
                    new Point(y1, x1)
                    , new Point(y2, x2)
                    , new Point(y3, x3));
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
                var tri = imageSvc.FindTriangle(row, col);
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

        /// Create an error response that also includes a custom error message
        private static IActionResult CreateErrorResult(ApiError err, int statusCode)
        {
            var res = new ObjectResult(err);
            res.StatusCode = statusCode;
            return res;
        }

        
    }
}
