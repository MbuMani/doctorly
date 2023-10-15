using doctorly.Core.Models;
using doctorly.Persistence.Models;

namespace doctorly.Core.MappingProfiles
{
    internal class ExternalEventContractProfile : AutoMapper.Profile
    {
        public ExternalEventContractProfile()
        {
           CreateMap<ExternalEventContract, Event>().ReverseMap();

           CreateMap<ExternalAttendeeContract, Attendee>().ReverseMap();
        }
    }
}
