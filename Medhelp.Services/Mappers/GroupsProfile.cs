using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Entities;

namespace Medhelp.Services.Mappers;

public class GroupsProfile : Profile
{
    public GroupsProfile()
    {
        CreateMap<ActiveSubstance, ActiveSubstanceModel>();
        CreateMap<GroupDto, ActiveSubstance>();
        
        CreateMap<DiseaseGroup, DiseaseGroupModel>();
        CreateMap<GroupDto, DiseaseGroup>();
        
        CreateMap<DrugAction, DrugActionModel>();
        CreateMap<GroupDto, DrugAction>();
        
        CreateMap<DrugForm, DrugFormModel>();
        CreateMap<GroupDto, DrugForm>();
        
        CreateMap<MedicalSpecialty, MedicalSpecialtyModel>();
        CreateMap<GroupDto, MedicalSpecialty>();
        
        CreateMap<OrganSystem, OrganSystemModel>();
        CreateMap<GroupDto, OrganSystem>();
    }
}