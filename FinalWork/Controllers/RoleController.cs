using App.Dtos.RoleDtos;
using App.Dtos.UserDtos;
using App.Helpers.Exceptions;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("role")]
    public class RoleController: Controller
    {
        private readonly ILogger<RoleController> _logger;

        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        /// <summary>
        /// Получить все роли
        /// </summary>
        [HttpGet()]
        public async Task<List<RoleResponseDto>> GetAll()
        {
            var roles = await _roleService.GetAll();

            return roles;
        }

        /// <summary>
        /// Получить роль по id
        /// </summary>
        [HttpGet("id/{id:int}")]
        public async Task<RoleResponseDto> GetById(int id)
        {
            var role = await _roleService.GetById(id)
                ?? throw new NotFoundException("Роли с таким id не существует");

            return role;
        }

        /// <summary>
        /// Получить роль по названию
        /// </summary>
        [HttpGet("name/{name}")]
        public async Task<RoleResponseDto> GetByEmail(string name)
        {

            var user = await _roleService.GetByName(name)
                ?? throw new NotFoundException("Роли с таким названием не существует");

            return user!;
        }

        /// <summary>
        /// Создать роль
        /// </summary>
        [HttpPost()]
        public async Task<RoleResponseDto> Create([FromBody] CreateRoleRequestDto dto)
        {
            var role = await _roleService.Create(dto);

            return role;
        }

        /// <summary>
        /// Обновить роль по id
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<RoleResponseDto> UpdateBuId(int id, [FromBody] UpdateRoleRequestDto dto)
        {
            var role = await _roleService.UpdateById(id, dto)
                ?? throw new NotFoundException("Роли с таким id не существует");

            return role;
        }

        /// <summary>
        /// Удалить роль по id
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<RoleResponseDto> DeleteById(int id)
        {
            var role = await _roleService.DeleteById(id)
                ?? throw new NotFoundException("Роли с таким id не существует");

            return role;
        }
    }
}
