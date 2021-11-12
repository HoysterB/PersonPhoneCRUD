using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(PersonPhone model)
        {
            try
            {
                await _context.PersonPhone.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(string phone)
        {
            try
            {
                var person = await _context.PersonPhone.FirstOrDefaultAsync(p => p.PhoneNumber == phone);

                if (person != null)
                {
                    person = await _context.PersonPhone.FirstOrDefaultAsync(p => p.PhoneNumber.Contains(phone));
                }

                _context.Remove(person);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync()
        {
            var query = await _context.PersonPhone
                .Include(pp => pp.Person)
                .Select(a => new PersonPhone
                {
                    BusinessEntityID = a.BusinessEntityID,
                    PhoneNumber = a.PhoneNumber,
                    Person = a.Person,
                    PhoneNumberTypeID = a.PhoneNumberTypeID,
                    PhoneNumberType = a.PhoneNumberType
                })
                .ToListAsync();

            return query;
        }

        public async Task<IEnumerable<PersonPhone>> FindByPersonId(int personId)
        {
            try
            {
                var personPhone = await _context.PersonPhone.Select(p => new PersonPhone
                {
                    BusinessEntityID = p.BusinessEntityID,
                    PhoneNumber = p.PhoneNumber,
                    PhoneNumberTypeID = p.PhoneNumberTypeID,
                    Person = p.Person,
                    PhoneNumberType = p.PhoneNumberType
                })
                .Where(p => p.BusinessEntityID == personId)
                .ToListAsync();

                return personPhone;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task Update(PersonPhone model)
        {
            throw new NotImplementedException();
        }
    }
}
