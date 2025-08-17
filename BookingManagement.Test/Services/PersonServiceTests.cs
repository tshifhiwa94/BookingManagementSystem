using AutoMapper;
using BookingManagement.Domain.Persons;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Services.PersonService;
using BookingManagement.Services.PersonService.Dtos;
using Moq;

public class PersonServiceTests
{
    private readonly Mock<IPersonRepository> _personRepoMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly PersonService _personService;

    public PersonServiceTests()
    {
        _personRepoMock = new Mock<IPersonRepository>();
        _mapperMock = new Mock<IMapper>();
        _personService = new PersonService(_personRepoMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnPersonDto_WhenInputIsValid()
    {
        // Arrange
        var input = new CreatePersonDto
        {
            Name = "John",
            Surname = "Doe",
            EmailAddress = "john.doe@example.com"
        };

        var personEntity = new Person { Name = input.Name, Surname = input.Surname, EmailAddress = input.EmailAddress };
        var personDto = new PersonDto { Id = Guid.NewGuid(), Name = input.Name, Surname = input.Surname, EmailAddress = input.EmailAddress };

        _mapperMock.Setup(m => m.Map<Person>(input)).Returns(personEntity);
        _personRepoMock.Setup(r => r.AddAsync(It.IsAny<Person>())).ReturnsAsync(personEntity);
        _mapperMock.Setup(m => m.Map<PersonDto>(personEntity)).Returns(personDto);


        // Act
        var result = await _personService.CreateAsync(input);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(input.Name, result.Name);
        Assert.Equal(input.Surname, result.Surname);
        Assert.Equal(input.EmailAddress, result.EmailAddress);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenPersonExists()
    {
        // Arrange
        var personId = Guid.NewGuid();
        var person = new Person { Id = personId };
        var isItemDeleted = true;

        _personRepoMock.Setup(r => r.GetAsync(personId)).ReturnsAsync(person);
        _personRepoMock.Setup(r => r.DeleteAsync(person)).ReturnsAsync(isItemDeleted);

        // Act
        var result = await _personService.DeleteAsync(personId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenPersonDoesNotExist()
    {
        // Arrange
        var personId = Guid.NewGuid();
        _personRepoMock.Setup(r => r.GetAsync(personId)).ReturnsAsync((Person)null);

        // Act
        var result = await _personService.DeleteAsync(personId);

        // Assert
        Assert.False(result);
    }

    public async Task DeleteAsync_ShouldReturnTrue_WhenPersonDoesExist()
    {
        // Arrange
        var personId = Guid.NewGuid();
        var person = new Person { Id = personId };

        _personRepoMock.Setup(r => r.GetAsync(personId)).ReturnsAsync(person);

        // Act
        var result = await _personService.DeleteAsync(personId);

        // Assert
        Assert.True(result);
    }


    [Fact]
    public async Task UpdateAsync_ShouldReturnNull_WhenPersonDoesNotExist()
    {
        // Arrange
        var updateDto = new UpdatePersonDto { Id = Guid.NewGuid() };
        _personRepoMock.Setup(r => r.GetAsync(updateDto.Id)).ReturnsAsync((Person)null);

        // Act
        var result = await _personService.UpdateAsync(updateDto);
        // Assert
        Assert.Null(result);
    }

}
