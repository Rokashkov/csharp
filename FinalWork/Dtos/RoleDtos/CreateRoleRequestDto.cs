using App.Entities;
using App.Mappers;

#nullable disable

namespace App.Dtos.RoleDtos
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public class CreateRoleRequestDto: IMapTo<Role>
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
