using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;
using Medhelp.Repositories;
using Medhelp.Services.Abstractions.Groups;

namespace Medhelp.Services.Groups;

public class ActiveSubstanceService : BaseGroupService<ActiveSubstance, ActiveSubstanceModel>, IActiveSubstanceService
{
    public ActiveSubstanceService(IActiveSubstanceRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
