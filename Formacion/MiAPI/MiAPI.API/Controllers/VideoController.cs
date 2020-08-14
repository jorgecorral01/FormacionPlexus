using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.Actions;
using MiAPI.API.Factories;
using MiAPI.API.swagger;
using MiAPI.Business.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

namespace MiAPI.API.Controllers {

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase{

        public static void Convention(ApiVersioningOptions options) {
            options.Conventions.Controller<VideoController>().HasApiVersions(ApiVersioning.Versions());
        }

        private readonly ClsVideoRepositoryFactory _clsVideoRepositoryFactory;
        
        public VideoController(ClsVideoRepositoryFactory clsVideoRepositoryFactory){
            _clsVideoRepositoryFactory = clsVideoRepositoryFactory;
        }
        
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Video>> Get(string name){
            Video video =  await _clsVideoRepositoryFactory.CreateFindVideoAction().Execute(name);
             if (video is null || video is VideoNotFound) return NotFound(new Video{name = name});
             return Ok(video);
        }

        
        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] Video video) {
            _clsVideoRepositoryFactory.CreateAddVideoAction().Execute(video);
            
            return Ok();
        }

        [Route("VideosAndUsers")]
        [HttpGet()] 
        public async Task<ActionResult<DataList>> VideosAndUsers(){

            DataList dataList = await _clsVideoRepositoryFactory.CreateGetAllVideosAndUserAction().Execute();
            
            return Ok(dataList);
        }
    }
}

// GET api/video/name
// post api/video/