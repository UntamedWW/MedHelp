using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;
using Medhelp.Repositories;
using Medhelp.Services.Abstractions.Groups;

namespace Medhelp.Services.Groups;

public class DrugFormService : BaseGroupService<DrugForm, DrugFormModel>, IDrugFormService 
{
    public DrugFormService(IDrugFormRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
