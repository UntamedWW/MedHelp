using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;
using Medhelp.Repositories;
using Medhelp.Services.Abstractions.Groups;

namespace Medhelp.Services.Groups;

public class DiseaseGroupService : BaseGroupService<DiseaseGroup, DiseaseGroupModel>, IDiseaseGroupService
{
    public DiseaseGroupService(IDiseaseGroupRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
