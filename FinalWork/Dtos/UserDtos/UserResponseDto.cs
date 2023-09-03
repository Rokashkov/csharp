using App.Mappers;
using App.Entities;
using App.Dtos.RoleDtos;

#nullable disable

namespace App.Dtos.UserDtos
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserResponseDto : IMapFrom<User>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Роли
        /// </summary>
        public List<RoleResponseDto> Roles { get; set; }
    }
}
