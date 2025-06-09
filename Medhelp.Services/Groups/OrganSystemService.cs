using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;
using Medhelp.Repositories;
using Medhelp.Services.Abstractions.Groups;

namespace Medhelp.Services.Groups;

public class OrganSystemService : BaseGroupService<OrganSystem, OrganSystemModel>, IOrganSystemService
{
    public OrganSystemService(IOrganSystemRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
