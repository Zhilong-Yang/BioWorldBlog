using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Response;
using BioWorld.Application.Tag.Queries;

namespace BioWorld.Application.Common.Interface
{
    public interface ITagRepoService
    {
        Task<Response<IReadOnlyList<TagItemDto>>> GetAllTagsAsync();
        Task<Response<IReadOnlyList<string>>> GetAllTagNamesAsync();
        Response<TagItemDto> GetTag(string normalizedName);
    }
}