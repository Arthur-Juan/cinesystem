using Application.Features.Authentication;
using Domain.Services;
using Infra.Services;
using Infra.Data.Efcore;
using Moq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.DTOs.Requests;
using AutoFixture;
using Application.DTOs.Response;
using System.Net.Mail;
using System.Collections;
using System;
using System.Runtime.CompilerServices;

namespace Tests.Auth;

public class MapperCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        var mockMapper = new Mock<IMapper>();
        fixture.Inject(mockMapper.Object);
    }
}

public class SignupTest
{
    private readonly IMapper _mapper;

    public SignupTest()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserSignupDTO>().ReverseMap();
            cfg.CreateMap<User, UserLoggedDTO>().ReverseMap();
        });
        var mapper = config.CreateMapper();
        _mapper = mapper;
    }

    private AppDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new AppDbContext(options);
        dbContext.Users.AddRange(GetFakeData().AsQueryable());
        dbContext.SaveChanges();
        return dbContext;
    }

    private List<User> GetFakeData()
    {
        var users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "userTest",
                LastName = "abcd",
                Email = "exists@email.com",
                Password = "abcd",
                Tickets = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
        return users;
    }

    [Theory]
    [InlineData("pass123", "anotherpass")]
    public async Task Test_ThrowErrorIfPasswordNotEqual(string password1, string password2)
    {
        ITokenService tokenService = new JwtAdapter();
        var dbContext = CreateDbContext();
        ICryptoService cryptoSerice = new BCryptAdapter();

        var sut = new Signup(dbContext, _mapper, tokenService, cryptoSerice);
        var dto = new UserSignupDTO(
            FirstName: "teste",
            LastName: "teste2",
            Email: "email123@email.com",
            Password: password1,
            ConfirmPassword: password2
        );

        await Assert.ThrowsAsync<Exception>(async () => await sut.SignupAsync(dto));

    }

    [Theory]
    [InlineData("notanemail")]
    public async Task Test_ShouldThrowAnExceptionIfEmailIsInvalid(string invalidEmail)
    {
        ITokenService tokenService = new JwtAdapter();
        var dbContext = CreateDbContext();
        ICryptoService cryptoSerice = new BCryptAdapter();

        var sut = new Signup(dbContext, _mapper, tokenService, cryptoSerice);

        var dto = new UserSignupDTO(
            FirstName: "teste",
            LastName: "teste2",
            Email: invalidEmail,
            Password: "pass",
            ConfirmPassword: "pass"
        );

        await Assert.ThrowsAsync<Exception>(async () => await sut.SignupAsync(dto));

    }

    [Fact]
    public async Task Test_ThrowExceptionIfEmailAlreadyIsInUse()
    {
        var dto = new UserSignupDTO(
            FirstName: "teste",
            LastName: "teste2",
            Email: "exists@email.com",
            Password: "pass",
            ConfirmPassword: "pass"
        );
        var user = GetFakeData().FirstOrDefault();
        var data = new List<User> { user }.AsQueryable();

        ITokenService tokenService = new JwtAdapter();

        var dbContext = CreateDbContext();
        ICryptoService cryptoSerice = new BCryptAdapter();
        var dbContextMock = new Mock<AppDbContext>();
        var dbSetMock = new Mock<DbSet<User>>();

        dbSetMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        dbSetMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        dbSetMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        dbSetMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


        var sut = new Signup(dbContext, _mapper, tokenService, cryptoSerice);


        await Assert.ThrowsAsync<Exception>(async () => await sut.SignupAsync(dto));

    }

    [Theory]
    [MemberData(nameof(MissingDataParams))]
    public async Task Test_ShouldThowExceptionIfRequiredDataIsMissing(DtoWithDataMissing dataMissing)
    {
        var dto = new UserSignupDTO(dataMissing?.FirstName, dataMissing?.LastName, dataMissing?.Email, dataMissing?.Password, dataMissing?.ConfirmPassword);

        ITokenService tokenService = new JwtAdapter();
        var dbContext = CreateDbContext();
        ICryptoService cryptoSerice = new BCryptAdapter();

        var sut = new Signup(dbContext, _mapper, tokenService, cryptoSerice);
        await Assert.ThrowsAsync<Exception>(async () => await sut.SignupAsync(dto));

    }

    public class DtoWithDataMissing
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }


    }


    public static IEnumerable<object[]> MissingDataParams()
    {
        // parameters to test send email success
        yield return new object[]
        {
            new DtoWithDataMissing
            {
                FirstName = "",
                LastName  = "Test",
                Email = "email@email.com",
                Password = "pass",
                ConfirmPassword = "pass"
            }

        };
        yield return new object[]
{
            new DtoWithDataMissing
            {
                FirstName = "Test",
                LastName  = "",
                Email = "email@email.com",
                Password = "pass",
                ConfirmPassword = "pass"
            }

};
        yield return new object[]
{
            new DtoWithDataMissing
            {
                FirstName = "Test",
                LastName  = "Test",
                Email = "",
                Password = "pass",
                ConfirmPassword = "pass"
            }

};
        yield return new object[]
{
            new DtoWithDataMissing
            {
                FirstName = "Test",
                LastName  = "Test",
                Email = "email@email.com",
                Password = "",
                ConfirmPassword = "pass"
            }

};
        yield return new object[]
{
            new DtoWithDataMissing
            {
                FirstName = "Test",
                LastName  = "Test",
                Email = "email@email.com",
                Password = "pass",
                ConfirmPassword = ""
            }

};


    }

}