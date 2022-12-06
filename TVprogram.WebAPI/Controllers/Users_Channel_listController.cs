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
    public class Users_Channel_listController : ControllerBase
    {
        private readonly IUser_Channel_listService user_Channel_ListService;
        private readonly IMapper mapper;

        /// <summary>
        /// users_channel_list controller
        /// </summary>
        public Users_Channel_listController(IUser_Channel_listService user_Channel_ListService,IMapper mapper)
        {
            this.user_Channel_ListService=user_Channel_ListService;
            this.mapper=mapper;
        }
        /// <summary>
        /// create user_channel_list
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser_Channel_list([FromQuery] Guid ChannelId,[FromQuery] Guid UserId,[FromBody] User_Channel_listModel user_Channel_List)
        {
            var response =user_Channel_ListService.CreateUser_Channel_list(ChannelId,UserId,user_Channel_List);
            return Ok(response);
        }

        
        /// <summary>
        /// Get users_channel_list by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetUsers_Channel_list([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =user_Channel_ListService.GetUsers_Channel_list(limit,offset);

            return Ok(mapper.Map<PageResponse<User_Channel_listResponse>>(pageModel));
        }
        /// <summary>
        /// Delete users_channel_list
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser_Channel_list([FromRoute] Guid id)
        {
            try
            {
                user_Channel_ListService.DeleteUser_Channel_list(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get user_channel_list
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser_Channel_list([FromRoute] Guid id)
        {
            try
            {
                var user_channel_listModel =user_Channel_ListService.GetUser_Channel_List(id);
                return Ok(mapper.Map<User_Channel_listResponse>(user_channel_listModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update user_channel_list
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser_Channel_list([FromRoute] Guid id, [FromBody] UpdateUser_Channel_listRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =user_Channel_ListService.UpdateUser_Channel_list(id,mapper.Map<UpdateUser_Channel_listModel>(model));
            return Ok(mapper.Map<User_Channel_listResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}