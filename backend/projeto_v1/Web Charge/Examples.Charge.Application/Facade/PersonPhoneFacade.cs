using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;
        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }
        public async Task<PersonPhoneResponse> Add(PersonPhoneDto model)
        {
            try
            {
                var entity = _mapper.Map<PersonPhone>(model);

                await _personPhoneService.Add(entity);
                var response = new PersonPhoneResponse();
                response.PersonPhoneObject = new PersonPhoneDto();
                response.PersonPhoneObject = model;
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Delete(string phone)
        {
            try
            {
                await _personPhoneService.Delete(phone);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PersonPhone>> FindAllAsync()
        {

            var result = await _personPhoneService.FindAllAsync();
            return result;


            //var response = new PersonPhoneResponse();
            //response.PersonPhoneObjects = new List<PersonPhoneDto>();
            //response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            //return response;
        }

        public Task<List<PersonPhone>> GetByPesonId(int personId)
        {
            var personPhone = _personPhoneService.FindByPersonId(personId);
            return personPhone;
        }

        public Task<PersonPhoneResponse> Update(PersonPhoneDto model)
        {
            throw new System.NotImplementedException();
        }
    }
}
