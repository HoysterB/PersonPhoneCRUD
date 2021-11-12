using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Person model)
        {
            try
            {
                await _context.Person.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddPhoneNumber(Person model)
        {

            var entity = await _context.Person.FindAsync(model.BusinessEntityID);

            entity.Phones = model.Phones;

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var person = await _context.Person.FindAsync(id);
                _context.Person.Remove(person);
                var save = await _context.SaveChangesAsync() > 0;

                return save ? true : false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<IEnumerable<Person>> FindAllAsync()
        {
            try
            {
                var query = await _context.Person
                          .Include(p => p.Phones)
                          .Select(a => new Person
                          {
                              BusinessEntityID = a.BusinessEntityID,
                              Name = a.Name,
                              Phones = a.Phones
                          })
                          .OrderBy(p => p.Name)
                          .ToListAsync();

                return query;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<Person> FindByIdAsync(int id)
        {
            try
            {
                var person = await _context.Person.Include(p => p.Phones)
                    .Select(a => new Person
                    {
                        BusinessEntityID = a.BusinessEntityID,
                        Name = a.Name,
                        Phones = a.Phones
                    }).FirstOrDefaultAsync(p => p.BusinessEntityID == id);

                return person;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Update(Person model)
        {

            var entity = await _context.Person.FindAsync(model.BusinessEntityID);
            if (entity == null)
            {
                throw new NullReferenceException("entidade nula");
            }

            if (model.Name == null)
            {
                model.Name = entity.Name;
            }

            entity.BusinessEntityID = model.BusinessEntityID;
            entity.Name = model.Name;
            entity.Phones = model.Phones;

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
