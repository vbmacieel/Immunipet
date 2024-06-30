using AutoMapper;
using Immunipet.API.DTO.Pet;
using Immunipet.API.Entities;

namespace Immunipet.API.Profiles;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<RequestPetDTO, Pet>();
        CreateMap<Pet, ResponsePetDTO>();
    }
}