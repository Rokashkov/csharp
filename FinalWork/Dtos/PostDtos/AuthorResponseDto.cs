using App.Entities;
using App.Mappers;

#nullable disable

namespace App.Dtos.PostDtos
{
    /// <summary>
    /// Автор
    /// </summary>
    public class AuthorResponseDto: IMapFrom<User>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
    }
}
