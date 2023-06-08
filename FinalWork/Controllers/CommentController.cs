using App.Dtos.PostDtos;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using App.Helpers.Exceptions;
using App.Dtos.CommentDtos;

namespace App.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController
    {
        private readonly ILogger<CommentController> _logger;

        private readonly ICommentService _commentService;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        /// <summary>
        /// Получить все комментарии
        /// </summary>
        [HttpGet()]
        public async Task<List<CommentResponseDto>> GetAll ()
        {
            var comments = await _commentService.GetAll();

            return comments;
        }

        /// <summary>
        /// Получить все комментарии по authorId
        /// </summary>
        [HttpGet("author/{authorId:int}")]
        public async Task<List<CommentResponseDto>> GetAllByAuthorId(int authorId)
        {
            var comments = await _commentService.GetAllByAuthorId(authorId)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return comments;
        }

        /// <summary>
        /// Получить комментарий по id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<CommentResponseDto> GetById(int id)
        {
            var comment = await _commentService.GetById(id)
                ?? throw new NotFoundException("Комментария с таким id не существует");

            return comment;
        }

        /// <summary>
        /// Создать комментарий
        /// </summary>
        [HttpPost()]
        public async Task<CommentResponseDto> Create([FromBody] CreateCommentRequestDto dto)
        {
            var comment = await _commentService.Create(dto)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return comment;
        }

        /// <summary>
        /// Обновить комментарий по id
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<CommentResponseDto> UpdateById(int id, [FromBody] UpdateCommentRequestDto dto)
        {
            var comment = await _commentService.UpdateById(id, dto)
                ?? throw new NotFoundException("Комментария с таким id не существует");

            return comment;
        }

        /// <summary>
        /// Удалить комментарий по id
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<CommentResponseDto> DeleteById(int id)
        {
            var post = await _commentService.DeleteById(id)
                ?? throw new NotFoundException("Комментария с таким id не существует");

            return post;
        }
    }
}
