using App.Dtos.PostDtos;
using App.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public interface IPostService
    {
        public Task<List<PostResponseDto>> GetAll();

        public Task<List<PostResponseDto>?> GetAllByAuthorId(int authorId);

        public Task<PostResponseDto?> GetById(int id);

        public Task<PostResponseDto?> Create(CreatePostRequestDto dto);

        public Task<PostResponseDto?> UpdateById(int id, UpdatePostRequestDto dto);

        public Task<PostResponseDto?> DeleteById(int id);
    }
    public class PostService: IPostService
    {
        private readonly AppDbContext _db;

        private readonly IMapper _mp;

        public PostService(AppDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<List<PostResponseDto>> GetAll()
        {
            var posts = await _db.Posts
                .Include(p => p.Author)
                .ProjectTo<PostResponseDto>(_mp.ConfigurationProvider)
                .ToListAsync();

            return posts;
        }

        public async Task<List<PostResponseDto>?> GetAllByAuthorId(int authorId)
        {
            var user = await _db.Users
                .Where(u => u.Id == authorId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var posts = await _db.Posts
                .Include(p => p.Author)
                .Where(p => p.Author == user)
                .ProjectTo<PostResponseDto>(_mp.ConfigurationProvider)
                .ToListAsync();

            return posts;
        }

        public async Task<PostResponseDto?> GetById(int id)
        {
            var post = await _db.Posts
                .ProjectTo<PostResponseDto>(_mp.ConfigurationProvider)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            return post;
        }

        public async Task<PostResponseDto?> Create(CreatePostRequestDto dto)
        {
            var user = await _db.Users
                .Where(u => u.Id == dto.AuthorId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var entry = await _db.Posts
                .AddAsync(new Post
                {
                    Author = user,
                    Text = dto.Text,
                    Title = dto.Title,
                });

            await _db.SaveChangesAsync();

            var post = entry.Entity;

            return _mp.Map<PostResponseDto>(post);
        }

        public async Task<PostResponseDto?> UpdateById(int id, UpdatePostRequestDto dto)
        {
            var post = await _db.Posts
                .Include(p => p.Author)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            post.Title = dto.Title;
            post.Text = dto.Text;

            await _db.SaveChangesAsync();

            return _mp.Map<PostResponseDto>(post);
        }

        public async Task<PostResponseDto?> DeleteById(int id)
        {
            var post = await _db.Posts
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            _db.Posts.Remove(post);

            await _db.SaveChangesAsync();

            return _mp.Map<PostResponseDto>(post);
        }
    }
}
