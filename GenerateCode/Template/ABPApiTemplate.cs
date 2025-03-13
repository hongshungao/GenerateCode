using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GenerateCode
{
    {{~ entity = EntityName ~}}
    {{~ description = Description ~}}

    public interface I{{entity}}AppService : IApplicationService
    {
        Task<{{entity}}Dto> GetAsync(Guid id);
        Task<List<{{entity}}Dto>> GetListAsync();
        Task<{{entity}}CreateDto> CreateAsync({{entity}}Dto input);
        Task<{{entity}}UpdateDto> UpdateAsync(Guid id, {{entity}}Dto input);
        Task DeleteAsync(Guid id);
    }

    public class {{entity}}AppService : ApplicationService, I{{entity}}AppService
    {
        private readonly IRepository<{{entity}}, Guid> _repository;

        public {{entity}}AppService(IRepository<{{entity}}, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<{{entity}}Dto> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return ObjectMapper.Map<{{entity}}, {{entity}}Dto>(entity);
        }

        public async Task<List<{{entity}}Dto>> GetListAsync()
        {
            var entities = await _repository.GetListAsync();
            return ObjectMapper.Map<List<{{entity}}>, List<{{entity}}Dto>>(entities);
        }

        public async Task<{{entity}}CreateDto> CreateAsync({{entity}}Dto input)
        {
            var entity = ObjectMapper.Map<{{entity}}CreateDto, {{entity}}>(input);
            entity = await _repository.InsertAsync(entity);
            return ObjectMapper.Map<{{entity}}, {{entity}}CreateDto>(entity);
        }

        public async Task<{{entity}}UpdateDto> UpdateAsync(Guid id, {{entity}}Dto input)
        {
            var entity = await _repository.GetAsync(id);
            ObjectMapper.Map(input, entity);
            entity = await _repository.UpdateAsync(entity);
            return ObjectMapper.Map<{{entity}}, {{entity}}UpdateDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}