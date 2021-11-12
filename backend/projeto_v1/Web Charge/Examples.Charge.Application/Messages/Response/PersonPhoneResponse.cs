using Examples.Charge.Application.Dtos;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Response
{
    public  class PersonPhoneResponse
    {
        public List<PersonPhoneDto> PersonPhoneObjects { get; set; }
        public PersonPhoneDto PersonPhoneObject { get; set; }
    }
}
