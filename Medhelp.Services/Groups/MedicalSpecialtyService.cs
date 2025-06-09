using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;
using Medhelp.Repositories;
using Medhelp.Services.Abstractions.Groups;

namespace Medhelp.Services.Groups;

public class MedicalSpecialtyService : BaseGroupService<MedicalSpecialty, MedicalSpecialtyModel>, IMedicalSpecialtyService
{
    public MedicalSpecialtyService(IMedicalSpecialtyRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
