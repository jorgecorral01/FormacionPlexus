using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MiAPI.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase {
        // GET api/video/name
        [HttpGet("{name}")]
        public ActionResult<Video> Get(string name) {
            return new Video { format = "jpg", name = "fiesta" };
        }
    }
}
