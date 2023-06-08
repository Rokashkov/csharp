using App.Entities;

#nullable disable

namespace App.Dtos.PostDtos
{
    /// <summary>
    /// Пост
    /// </summary>
    public class UpdatePostRequestDto
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }
    }
}
