using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;
using Medhelp.Repositories;
using Medhelp.Services.Abstractions.Groups;

namespace Medhelp.Services.Groups;

public class DrugActionService : BaseGroupService<DrugAction, DrugActionModel>, IDrugActionService
{
    public DrugActionService(IDrugActionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
