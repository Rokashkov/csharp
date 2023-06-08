using App.Dtos.UserDtos;
using App.Dtos.UserOnRoleDto;
using App.Services;
using App.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("user-on-role")]
    public class UserOnRoleController
    {
        private readonly ILogger<UserOnRoleController> _logger;

        private readonly IUserOnRoleService _userOnRoleService;

        public UserOnRoleController(ILogger<UserOnRoleController> logger, IUserOnRoleService userOnRoleService)
        {
            _logger = logger;
            _userOnRoleService = userOnRoleService;
        }

        /// <summary>
        /// Присвоить роль
        /// </summary>
        [HttpPost()]
        public async Task<UserResponseDto> GrantRole([FromBody] GrantRoleRequestDto dto)
        {
            var user = await _userOnRoleService.GrantRole(dto)
                ?? throw new NotFoundException("Пользователя или роли с таким id не существует");

            return user;
        }

        /// <summary>
        /// Лишить роли
        /// </summary>
        [HttpDelete()]
        public async Task<UserResponseDto> RemoveRole([FromBody] RemoveRoleRequestDto dto)
        {
            var user = await _userOnRoleService.RemoveRole(dto)
                ?? throw new NotFoundException("Пользователя или роли с таким id не существует");

            return user;
        }
    }
}
