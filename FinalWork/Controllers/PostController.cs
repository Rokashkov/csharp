using App.Dtos.PostDtos;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using App.Helpers.Exceptions;

namespace App.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController
    {
        private readonly ILogger<PostController> _logger;

        private readonly IPostService _postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        /// <summary>
        /// Получить все посты
        /// </summary>
        [HttpGet()]
        public async Task<List<PostResponseDto>> GetAll ()
        {
            var posts = await _postService.GetAll();

            return posts;
        }

        /// <summary>
        /// Получить все посты по authorId
        /// </summary>
        [HttpGet("author/{authorId:int}")]
        public async Task<List<PostResponseDto>> GetAllByAuthorId(int authorId)
        {
            var posts = await _postService.GetAllByAuthorId(authorId)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return posts;
        }

        /// <summary>
        /// Получить пост по id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<PostResponseDto> GetById(int id)
        {
            var post = await _postService.GetById(id)
                ?? throw new NotFoundException("Поста с таким id не существует");

            return post;
        }

        /// <summary>
        /// Создать пост
        /// </summary>
        [HttpPost()]
        public async Task<PostResponseDto> Create([FromBody] CreatePostRequestDto dto)
        {
            var post = await _postService.Create(dto)
                ?? throw new NotFoundException("Пользователя с таким id не существует");

            return post;
        }

        /// <summary>
        /// Обновить пост по id
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<PostResponseDto> UpdateById(int id, [FromBody] UpdatePostRequestDto dto)
        {
            var post = await _postService.UpdateById(id, dto)
                ?? throw new NotFoundException("Поста с таким id не существует");

            return post;
        }

        /// <summary>
        /// Удалить пост по id
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<PostResponseDto> DeleteById(int id)
        {
            var post = await _postService.DeleteById(id)
                ?? throw new NotFoundException("Поста с таким id не существует");

            return post;
        }
    }
}
