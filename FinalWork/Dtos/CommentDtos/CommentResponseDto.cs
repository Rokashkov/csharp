using App.Dtos.PostDtos;
using App.Entities;
using App.Mappers;

#nullable disable

namespace App.Dtos.CommentDtos
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class CommentResponseDto: IMapFrom<Comment>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public AuthorResponseDto Author { get; set; }

        /// <summary>
        /// Пост
        /// </summary>
        public PostResponseDto Post { get; set; }
    }
}
