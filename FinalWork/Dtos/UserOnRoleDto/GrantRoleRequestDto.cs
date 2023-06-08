namespace App.Dtos.UserOnRoleDto
{
    /// <summary>
    /// Роль пользователь
    /// </summary>
    public class GrantRoleRequestDto
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Id роли
        /// </summary>
        public int RoleId { get; set; }
    }
}