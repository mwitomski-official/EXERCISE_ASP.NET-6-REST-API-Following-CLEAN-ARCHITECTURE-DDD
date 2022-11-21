using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Step: 1 Check if user already exists

        // Step: 2 Create user (generate unique ID)

        // Step: 3 Create JWT token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new(userId, firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
        => new(Guid.NewGuid(), "firstName", "lastName", email, "token");
}
