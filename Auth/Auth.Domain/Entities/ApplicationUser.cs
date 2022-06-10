using Microsoft.AspNetCore.Identity;
using Neuron.Common.Data.Entity;

namespace Auth.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, ISoftDeletable
    {
    }
}