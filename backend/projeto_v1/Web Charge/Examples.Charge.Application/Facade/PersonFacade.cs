using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<List<Person>> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            
            return result;
        }

        public async Task<PersonResponse> Add(PersonDto model)
        {


            try
            {
                var entity = _mapper.Map<Person>(model);
                await _personService.Add(entity);
                var response = new PersonResponse();
                response.PersonObject = new PersonDto();
                response.PersonObject = model;

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PersonResponse> Update(PersonDto model)
        {
            var entity = _mapper.Map<Person>(model);
            try
            {
                await _personService.Update(entity);

                var response = new PersonResponse();
                response.PersonObject = new PersonDto();
                response.PersonObject = model;

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int modelId)
        {
            try
            {
                var entity = await _personService.Delete(modelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PersonResponse> FindById(int id)
        {
            try
            {
                var entity = await _personService.FindByIdAsync(id);

                var response = new PersonResponse();
                response.PersonObject = _mapper.Map<PersonDto>(entity);



                //(result.Select(x => _mapper.Map<PersonDto>(x)));
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PersonResponse> AddPhoneNumber(PersonDto model)
        {
            var entity = _mapper.Map<Person>(model);

            try
            {
                await _personService.AddPhoneNumber(entity);

                var response = new PersonResponse();
                response.PersonObject = new PersonDto();
                response.PersonObject = response;

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
