using AutoMapper;
using RecordAssist.Health.Data.Model;
using RecordAssist.Health.DTOs.Encounters;
using RecordAssist.Health.DTOs.Patients;
namespace RecordAssist.Health.API
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
