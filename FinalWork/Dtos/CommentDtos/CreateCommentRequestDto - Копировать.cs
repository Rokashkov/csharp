#nullable disable

namespace App.Dtos.CommentDtos
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class CreateCommentRequestDto
    {
        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Id поста
        /// </summary>
        public int PostId { get; set; }
    }
}
