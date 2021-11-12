using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonPhoneController : BaseController
    {
        public readonly IPersonFacade _person;
        public PersonPhoneController(IPersonFacade person)
        {
            _person = person;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _person.FindAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto model)
        {
            var addModel = await _person.Add(model);
            return Ok(addModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _person.Delete(id);
            return Response(null);
        }


        [HttpPut("update")]
        public async Task<ActionResult<PersonResponse>> Update(PersonDto model)
        {
            try
            {
                await _person.Update(model);
                return Ok(model.BusinessEntityID);
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetById(int id)
        {
            try
            {
                var person = await _person.FindById(id);
                return Ok(person);
            }
            catch (System.Exception)
            {
                return BadRequest("Usuario não achado");
            }
        }
    }


}
