using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // [Step 1] Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new InvalidOperationException("User with given email already exists.");
        }

        // [Step 2] Create user (generate unique ID) & Persist to DB
        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // [Step 3] Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // [Step 1] Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            // SECURITY INCIDENT WE SHOULDN'T RETURN THESE INFORMATION - ONLY FOR LEARNING PROCESS
            throw new Exception("User with given email does not exist.");

        // [Step 2] Validate the password is correct
        if (user.Password != password)
            throw new AccessViolationException("Invalid password.");

        // [Step 3] Create JWT token 
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new(user, token);
    }

}
