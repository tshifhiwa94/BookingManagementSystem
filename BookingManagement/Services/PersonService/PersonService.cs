using AutoMapper;
using BookingManagement.Domain.Persons;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepo
            , IMapper mapper)
        {
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public async Task<PersonDto> CreateAsync(CreatePersonDto input)
        {
            var person = _mapper.Map<Person>(input);

            await _personRepo.AddAsync(person);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var person = await _personRepo.GetAsync(id);
            if (person == null) return false;
            await _personRepo.DeleteAsync(person);
            return true;
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PersonDto>>(await _personRepo.GetAllAsync(p => p.Address, p => p.User));
        }

        public async Task<PersonDto> GetAsync(Guid id)
        {
            var person = await _personRepo.GetAsync(id, p => p.User, p => p.Address);
            if (person is null) return null;
            return _mapper.Map<PersonDto>(person);
        }



        public async Task<PersonDto> UpdateAsync(UpdatePersonDto personDto)
        {
            var person = await _personRepo.GetAsync(personDto.Id);
            if (person is null) return null;

            // Use AutoMapper to map to the existing entity
            _mapper.Map(personDto, person);
            await _personRepo.UpdateAsync(person);

            return _mapper.Map<PersonDto>(person);
        }


    }

}
