using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.API.Factories;
using MiAPI.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MiAPI.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase{
        private readonly ClsVideoRepositoryFactory _clsVideoRepositoryFactory;
        
        public VideoController(ClsVideoRepositoryFactory clsVideoRepositoryFactory){
            _clsVideoRepositoryFactory = clsVideoRepositoryFactory;
        }

        // GET api/video/name
        [HttpGet("{name}")]
        public async Task<ActionResult<Video>> Get(string name){
            Video video =  await _clsVideoRepositoryFactory.CreateFindVideoAction().Execute(name);
             if (video is null) return NotFound(new Video());
             return Ok(video);
        }

        // post api/video/
        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] Video video) {
            _clsVideoRepositoryFactory.CreateAddVideoAction().Execute(video);
            
            return Ok();
        }
    }
}
