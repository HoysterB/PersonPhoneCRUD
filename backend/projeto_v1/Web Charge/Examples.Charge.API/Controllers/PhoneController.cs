using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : BaseController
    {
        public readonly IPersonPhoneFacade _personPhone;
        public PhoneController(IPersonPhoneFacade personPhone)
        {
            _personPhone = personPhone;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _personPhone.FindAllAsync());
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonPhoneDto model)
        {
            try
            {
                await _personPhone.Add(model);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetByPersonId(int personId)
        {
            try
            {
                var personPhone = await _personPhone.GetByPesonId(personId);
                return Ok(personPhone);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{number}")]
        public async Task<IActionResult> DeleteByNumber(string number)
        {
            try
            {
                await _personPhone.Delete(number);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
