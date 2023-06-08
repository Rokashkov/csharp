using App.Dtos.CommentDtos;
using App.Dtos.PostDtos;
using App.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public interface ICommentService
    {
        public Task<List<CommentResponseDto>> GetAll();

        public Task<List<CommentResponseDto>?> GetAllByAuthorId(int authorId);

        public Task<CommentResponseDto?> GetById(int id);

        public Task<CommentResponseDto?> Create(CreateCommentRequestDto dto);

        public Task<CommentResponseDto?> UpdateById(int id, UpdateCommentRequestDto dto);

        public Task<CommentResponseDto?> DeleteById(int id);
    }

    public class CommentService: ICommentService
    {
        private readonly AppDbContext _db;

        private readonly IMapper _mp;

        public CommentService(AppDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        public async Task<List<CommentResponseDto>> GetAll()
        {
            var comments = await _db.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .ProjectTo<CommentResponseDto>(_mp.ConfigurationProvider)
                .ToListAsync();

            return comments;
        }

        public async Task<List<CommentResponseDto>?> GetAllByAuthorId(int authorId)
        {
            var user = await _db.Users
                .Where(u => u.Id == authorId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var comments = await _db.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .Where(c => c.Author == user)
                .ProjectTo<CommentResponseDto>(_mp.ConfigurationProvider)
                .ToListAsync();

            return comments;
        }

        public async Task<CommentResponseDto?> GetById(int id)
        {
            var comment = await _db.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .ProjectTo<CommentResponseDto>(_mp.ConfigurationProvider)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (comment == null)
            {
                return null;
            }

            return comment;
        }

        public async Task<CommentResponseDto?> Create(CreateCommentRequestDto dto)
        {
            var user = await _db.Users
                .Where(u => u.Id == dto.AuthorId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var post = await _db.Posts
                .Where(p => p.Id == dto.AuthorId)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            var entry = await _db.Comments
                .AddAsync(new Comment
                {
                    Author = user,
                    Post = post,
                    Text = dto.Text,
                });

            await _db.SaveChangesAsync();

            var comment = entry.Entity;

            return _mp.Map<CommentResponseDto>(comment);
        }

        public async Task<CommentResponseDto?> UpdateById(int id, UpdateCommentRequestDto dto)
        {
            var comment = await _db.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (comment == null)
            {
                return null;
            }

            comment.Text = dto.Text;

            await _db.SaveChangesAsync();

            return _mp.Map<CommentResponseDto>(comment);
        }

        public async Task<CommentResponseDto?> DeleteById(int id)
        {
            var comment = await _db.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (comment == null)
            {
                return null;
            }

            _db.Comments.Remove(comment);

            await _db.SaveChangesAsync();

            return _mp.Map<CommentResponseDto>(comment);
        }
    }
}