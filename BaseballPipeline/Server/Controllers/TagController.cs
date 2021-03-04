namespace BaseballPipeline.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BaseballPipeline.Server.Data;
    using BaseballPipeline.Server.Data.Entities;
    using BaseballPipeline.Shared.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class TagController : ControllerBase
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        //private readonly IMediator mediator;
        private readonly ILogger<TagController> logger;

        //public TagController(ICorrelationContextAccessor correlationContextAccessor, IMediator mediator) : base(correlationContextAccessor, mediator)
        //{
        //}

        public TagController(AppDBContext context, IMapper mapper, ILogger<TagController> logger)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            //this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagModel>>> GetTags()
        {
            return await context.Tags.ProjectTo<TagModel>(mapper.ConfigurationProvider).ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Tag>>> GetCollection()
        //{
        //    var result = await this.Mediator.Send(new GetAllActivityRequest<Tag>(this.CorrelationId)).ConfigureAwait(false);

        //    if (result == null)
        //    {
        //        return Ok(Enumerable.Empty<Tag>());
        //    }

        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<TagModel>> GetTag(int id)
        {
            var tag = await context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }
            else
            {
                return mapper.Map<TagModel>(tag);
            }

        }

        [HttpPost]
        public async Task<ActionResult<TagModel>> PostTag(TagModel tagModel)
        {
            Tag tag = mapper.Map<Tag>(tagModel);
            context.Tags.Add(tag);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTag), new { id = tag.TagId }, tag);
        }

        [HttpPut]
        public async Task<ActionResult<TagModel>> Put(TagModel tagModel)
        {
            Tag tag = mapper.Map<Tag>(tagModel);
            context.Entry(tag).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return tagModel;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = new Tag { TagId = id };
            context.Remove(item);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
