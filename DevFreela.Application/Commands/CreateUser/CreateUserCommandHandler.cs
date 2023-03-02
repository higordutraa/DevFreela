using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateUserCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Fullname, request.Email, request.BirthDate);

            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
