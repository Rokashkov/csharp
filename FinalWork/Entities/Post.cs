#nullable disable

namespace App.Entities
{
    /// <summary>
    /// Пост
    /// </summary>
    public class Post
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
        public User Author { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
