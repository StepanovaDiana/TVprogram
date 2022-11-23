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
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelService channelService;
        private readonly IMapper mapper;

        /// <summary>
        /// Channels controller
        /// </summary>
        public ChannelsController(IChannelService channelService,IMapper mapper)
        {
            this.channelService=channelService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get channels by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetChannels([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =channelService.GetChannels(limit,offset);

            return Ok(mapper.Map<PageResponse<ChannelResponse>>(pageModel));
        }
        /// <summary>
        /// Delete channels
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteChannel([FromRoute] Guid id)
        {
            try
            {
                channelService.DeleteChannel(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get channel
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetChannel([FromRoute] Guid id)
        {
            try
            {
                var channelModel =channelService.GetChannel(id);
                return Ok(mapper.Map<ChannelResponse>(channelModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update channel
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateChannel([FromRoute] Guid id, [FromBody] UpdateChannelRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =channelService.UpdateChannel(id,mapper.Map<UpdateChannelModel>(model));
            return Ok(mapper.Map<ChannelResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}