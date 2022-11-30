using AutoMapper;
using TVprogram.Services.Abstract;
using TVprogram.Services.Models;
using TVprogram.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TVprogram.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramService programService;
        private readonly IMapper mapper;

        /// <summary>
        /// Programs controller
        /// </summary>
        public ProgramsController(IProgramService programService,IMapper mapper)
        {
            this.programService=programService;
            this.mapper=mapper;
        }
        /// <summary>
        /// create program
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateProgram([FromBody] CreateProgramRequest program)
        {
            var validationResult = program.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =programService.CreateProgram(mapper.Map<CreateProgramModel>(program));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        
        /// <summary>
        /// Get programs by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetPrograms([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =programService.GetPrograms(limit,offset);

            return Ok(mapper.Map<PageResponse<ProgramResponse>>(pageModel));
        }
        /// <summary>
        /// Delete programs
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProgram([FromRoute] Guid id)
        {
            try
            {
                programService.DeleteProgram(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get program
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProgram([FromRoute] Guid id)
        {
            try
            {
                var programModel =programService.GetProgram(id);
                return Ok(mapper.Map<ProgramResponse>(programModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update program
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProgram([FromRoute] Guid id, [FromBody] UpdateProgramRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =programService.UpdateProgram(id,mapper.Map<UpdateProgramModel>(model));
            return Ok(mapper.Map<ProgramResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}