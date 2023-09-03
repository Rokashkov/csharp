using App.Dtos.RoleDtos;
using App.Dtos.UserDtos;
using App.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public interface IRoleService
    {
        public Task<List<RoleResponseDto>> GetAll();

        public Task<RoleResponseDto?> GetById(int id);

        public Task<RoleResponseDto?> GetByName(string name);

        public Task<RoleResponseDto> Create(CreateRoleRequestDto dto);

        public Task<RoleResponseDto?> UpdateById(int id, UpdateRoleRequestDto dto);

        public Task<RoleResponseDto?> DeleteById(int id);
    }

    public class RoleService: IRoleService
    {
        private readonly AppDbContext _db;

        private readonly IMapper _mp;

        public RoleService(AppDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<List<RoleResponseDto>> GetAll()
        {
            var roles = await _db.Roles
                .AsNoTracking()
                .ProjectTo<RoleResponseDto>(_mp.ConfigurationProvider)
                .ToListAsync();

            return roles;
        }

        public async Task<RoleResponseDto?> GetById(int id)
        {
            var role = await _db.Roles
                .AsNoTracking()
                .ProjectTo<RoleResponseDto>(_mp.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == id);

            return role;
        }

        public async Task<RoleResponseDto?> GetByName(string name)
        {
            var role = await _db.Roles
                .AsNoTracking()
                .ProjectTo<RoleResponseDto>(_mp.ConfigurationProvider)
                .FirstOrDefaultAsync(r => r.Name == name);

            return role;
        }

        public async Task<RoleResponseDto> Create(CreateRoleRequestDto dto)
        {
            var data = _mp.Map<Role>(dto);
            var entry = await _db.Roles
                .AddAsync(data);

            await _db.SaveChangesAsync();

            var role = entry.Entity;

            return _mp.Map<RoleResponseDto>(role);
        }

        public async Task<RoleResponseDto?> UpdateById(int id, UpdateRoleRequestDto dto)
        {
            var role = await _db.Roles
                .SingleOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return null;
            }

            _db.Entry(role).CurrentValues.SetValues(dto);

            await _db.SaveChangesAsync();

            return _mp.Map<RoleResponseDto>(role);
        }

        public async Task<RoleResponseDto?> DeleteById(int id)
        {
            var candidate = await _db.Roles
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
            {
                return null;
            }

            var role = _db.Roles
                .Remove(candidate).Entity;

            await _db.SaveChangesAsync();

            return _mp.Map<RoleResponseDto>(role);
        }
    }
}
