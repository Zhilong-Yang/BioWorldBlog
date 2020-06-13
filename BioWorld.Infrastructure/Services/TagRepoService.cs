using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Response;
using BioWorld.Application.Tag.Queries;
using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.EntitySpec;
using BioWorld.Infrastructure.Repository;
using Microsoft.Extensions.Logging;

namespace BioWorld.Infrastructure.Services
{
    public class TagRepoService : ApplicationService
    {
        private readonly IRepository<TagEntity> _tagRepository;

        public TagRepoService(IRepository<TagEntity> tagRepository,
            ILogger<ApplicationService> logger = null) : base(logger)
        {
            _tagRepository = tagRepository;
        }

        public Task<Response<IReadOnlyList<TagItemDto>>> GetAllTagsAsync()
        {
            return TryExecuteAsync<IReadOnlyList<TagItemDto>>(async () =>
            {
                var list = await _tagRepository.SelectAsync(t => new TagItemDto
                {
                    Id = t.Id,
                    NormalizedTagName = t.NormalizedName,
                    TagName = t.DisplayName
                });

                return new SuccessResponse<IReadOnlyList<TagItemDto>>(list);
            });
        }

        public Task<Response<IReadOnlyList<string>>> GetAllTagNamesAsync()
        {
            return TryExecuteAsync<IReadOnlyList<string>>(async () =>
            {
                var tagNames = await _tagRepository.SelectAsync(t => t.DisplayName);
                return new SuccessResponse<IReadOnlyList<string>>(tagNames);
            });
        }

        public Response<TagItemDto> GetTag(string normalizedName)
        {
            return TryExecute(() =>
            {
                var tag = _tagRepository.SelectFirstOrDefault(new TagSpec(normalizedName), tg => new TagItemDto
                {
                    Id = tg.Id,
                    NormalizedTagName = tg.NormalizedName,
                    TagName = tg.DisplayName
                });
                return new SuccessResponse<TagItemDto>(tag);
            });
        }
    }
}