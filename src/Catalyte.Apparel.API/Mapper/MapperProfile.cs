using AutoMapper;
using Catalyte.SuperHealth.Data.Model;
using Catalyte.SuperHealth.DTOs.Encounters;
using Catalyte.SuperHealth.DTOs.Patients;
namespace Catalyte.SuperHealth.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Encounter, EncounterDTO>().ReverseMap();
        }

    }
}
