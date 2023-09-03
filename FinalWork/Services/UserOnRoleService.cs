using App.Dtos.UserDtos;
using App.Dtos.UserOnRoleDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public interface IUserOnRoleService
    {
        public Task<UserResponseDto?> GrantRole(GrantRoleRequestDto dto);

        public Task<UserResponseDto?> RemoveRole(RemoveRoleRequestDto dto);
    }

    public class UserOnRoleService: IUserOnRoleService
    {
        private readonly AppDbContext _db;

        private readonly IMapper _mp;

        public UserOnRoleService(AppDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<UserResponseDto?> GrantRole(GrantRoleRequestDto dto)
        {
            var user = _db.Users
                .Include(u => u.Roles)
                .Where(u => u.Id == dto.UserId)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var role = _db.Roles
                .Where(r => r.Id == dto.RoleId)
                .FirstOrDefault();

            if (role == null)
            {
                return null;
            }

            user.Roles.Add(role);

            await _db.SaveChangesAsync();

            return _mp.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> RemoveRole(RemoveRoleRequestDto dto)
        {
            var user = _db.Users
                .Include(u => u.Roles)
                .Where(u => u.Id == dto.UserId)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var role = _db.Roles
                .Where(r => r.Id == dto.RoleId)
                .FirstOrDefault();

            if (role == null)
            {
                return null;
            }

            user.Roles.Remove(role);

            await _db.SaveChangesAsync();

            return _mp.Map<UserResponseDto>(user);
        }
    }
}
