using Microsoft.AspNetCore.Mvc;
using App.Services;
using App.Helpers.Exceptions;
using App.Dtos.UserDtos;

namespace App.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        [HttpGet()]
        public async Task<List<UserResponseDto>> GetAll()
        {
            var users = await _userService.GetAll();

            return users;
        }

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        [HttpGet("id/{id:int}")]
        public async Task<UserResponseDto> GetById(int id)
        {
            var user = await _userService.GetById(id)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return user;
        }

        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        [HttpGet("email/{email}")]
        public async Task<UserResponseDto> GetByEmail(string email)
        {

            var user = await _userService.GetByEmail(email)
                ?? throw new NotFoundException("Пользователя с таким email не существует");

            return user;
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        [HttpPost()]
        public async Task<UserResponseDto> Create([FromBody] CreateUserRequestDto dto)
        {
            var user = await _userService.Create(dto);

            return user;
        }

        /// <summary>
        /// Обновить пользователя по id
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<UserResponseDto> UpdateBuId(int id, [FromBody] UpdateUserRequestDto dto)
        {
            var user = await _userService.UpdateById(id, dto)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return user;
        }

        /// <summary>
        /// Удалить пользователя по id
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<UserResponseDto> DeleteById(int id)
        {
            var user = await _userService.DeleteById(id)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return user;
        }
    }
}