using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.API.Factories;
using MiAPI.Business.Dtos;
using MiAPI.Repositories;
using MiAPI.Repositories.interfaces;
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
            //return new Video();
             var video =  await _clsVideoRepositoryFactory.CreateFindVideoAction().Execute(name);
             return video;
             
        }
    }
}
