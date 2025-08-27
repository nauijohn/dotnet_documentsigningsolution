namespace DocumentSigningSolution.Application.Authentication.Commands.Register;
public class RegisterCommandHandler(
    IUserRepository _userRepository,
    IJwtTokenGenerator _jwtTokenGenerator)
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }


        var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
