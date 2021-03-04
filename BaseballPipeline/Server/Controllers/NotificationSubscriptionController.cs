namespace BaseballPipeline.Server.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BaseballPipeline.Server.Data;
    using BaseballPipeline.Server.Data.Entities;
    using BaseballPipeline.Shared.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class NotificationSubscriptionController : ControllerBase
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        private readonly ILogger<TagController> logger;


        public NotificationSubscriptionController(AppDBContext context, IMapper mapper, ILogger<TagController> logger)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationSubscriptionModel>>> Get()
        {
            return await context.NotificationSubscriptions.ProjectTo<NotificationSubscriptionModel>(mapper.ConfigurationProvider).ToListAsync();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<NotificationSubscriptionModel>> Post(NotificationSubscriptionModel nsModel)
        {
            NotificationSubscription ns = mapper.Map<NotificationSubscription>(nsModel);
            context.NotificationSubscriptions.Add(ns);
            await context.SaveChangesAsync();

            return nsModel;
        }
    }
}
