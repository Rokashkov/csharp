using App.Mappers;
using App.Entities;

#nullable disable

namespace App.Dtos.UserDtos
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UpdateUserRequestDto : IMapTo<User>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
