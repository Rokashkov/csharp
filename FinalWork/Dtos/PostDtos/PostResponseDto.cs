using App.Entities;
using App.Mappers;

#nullable disable

namespace App.Dtos.PostDtos
{
    /// <summary>
    /// Пост
    /// </summary>
    public class PostResponseDto: IMapFrom<Post>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public AuthorResponseDto Author { get; set; }
    }
}
