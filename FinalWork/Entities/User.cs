#nullable disable

namespace App.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Роли
        /// </summary>
        public List<Role> Roles { get; set; } = new List<Role>();

        /// <summary>
        /// Посты
        /// </summary>
        public List<Post> Posts { get; set; } = new List<Post>();

        /// <summary>
        /// Комментарии
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
