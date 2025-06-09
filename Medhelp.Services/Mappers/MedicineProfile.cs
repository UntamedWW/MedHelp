using AutoMapper;
using Medhelp.Contracts;
using Medhelp.Domain.Entities;

namespace Medhelp.Services.Mappers;

public class MedicineProfile : Profile
{
    public MedicineProfile()
    {
        CreateMap<Medicine, MedicineModel>();
    }
}