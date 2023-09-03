using App.Entities;
using App.Mappers;

#nullable disable

namespace App.Dtos.RoleDtos
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public class RoleResponseDto: IMapFrom<Role>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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
