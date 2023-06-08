using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using App.Entities;
using App.Dtos.UserDtos;

namespace App.Services
{
    public interface IUserService
    {
        public Task<List<UserResponseDto>> GetAll();

        public Task<UserResponseDto?> GetById(int id);

        public Task<UserResponseDto?> GetByEmail(string email);

        public Task<UserResponseDto> Create(CreateUserRequestDto dto);

        public Task<UserResponseDto?> UpdateById(int id,UpdateUserRequestDto dto);

        public Task<UserResponseDto?> DeleteById(int id);
    }

    public class UserService: IUserService
    {
        private readonly AppDbContext _db;

        private readonly IMapper _mp;

        public UserService(AppDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<List<UserResponseDto>> GetAll()
        {
            var users = await _db.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ProjectTo<UserResponseDto>(_mp.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<UserResponseDto?> GetById(int id)
        {
            var user = await _db.Users
                .AsNoTracking()
                .ProjectTo<UserResponseDto>(_mp.ConfigurationProvider)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<UserResponseDto?> GetByEmail(string email)
        {
            var user = await _db.Users
                .AsNoTracking()
                .ProjectTo<UserResponseDto>(_mp.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<UserResponseDto> Create(CreateUserRequestDto dto)
        {
            var data = _mp.Map<User>(dto);
            var entry = await _db.Users
                .AddAsync(data);

            await _db.SaveChangesAsync();

            var user = entry.Entity;

            return _mp.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> UpdateById(int id, UpdateUserRequestDto dto)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(c => c.Id == id);

            if (user == null)
            {
                return null;
            }

            _db.Entry(user).CurrentValues.SetValues(dto);

            await _db.SaveChangesAsync();

            return _mp.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> DeleteById(int id)
        {
            var candidate = await _db.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
            {
                return null;
            }

            var user = _db.Users
                .Remove(candidate).Entity;

            await _db.SaveChangesAsync();

            return _mp.Map<UserResponseDto>(user);
        }
    }
}
