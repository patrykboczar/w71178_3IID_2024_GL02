using Microsoft.AspNetCore.Mvc;
using lab6;

namespace lab7.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            return _personRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson(Person person)
        {
            _personRepository.Add(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            var existingPerson = _personRepository.GetById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            _personRepository.Update(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            _personRepository.Remove(id);
            return NoContent();
        }
    }
}