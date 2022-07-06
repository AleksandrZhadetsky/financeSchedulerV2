using AutoMapper;
using Domain.DTOs;
using Domain.Responses.Identity;
using Domain.Entities.User;
using Handlers.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Handlers.User.Identity.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, IdentityResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerator tokenGenerator;

        public LoginHandler(
            IMapper mapper,
            UserManager<AppUser> userManager,
            TokenGenerator tokenGenerator
        )
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<IdentityResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            var userExists = user is not null;
            var loginSucceeded = await userManager.CheckPasswordAsync(user, request.Password);
            var errors = new List<string>();

            if (userExists && loginSucceeded)
            {
                var token = await tokenGenerator.GetTokenAsync(user);
                var userModel = mapper.Map<AppUser, UserDTO>(user);

                return new IdentityResponse(userModel, token, true);
            }

            if (!userExists)
            {
                errors.Add("User doesn't exist or wrong user name provided");
            }

            if (!loginSucceeded)
            {
                errors.Add("Wrong password");
            }

            return new IdentityResponse(false, errors);
        }
    }
}
