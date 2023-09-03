#nullable disable

namespace App.Entities
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class Comment
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
        public User Author { get; set; }

        /// <summary>
        /// Пост
        /// </summary>
        public Post Post { get; set; }
    }
}
