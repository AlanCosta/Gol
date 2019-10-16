using WebMotors.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebMotors.IO.Site.Models
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor accessor;

        public AspNetUser(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }
        public string Name => accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return accessor.HttpContext.User.Claims;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(accessor.HttpContext.User.GetUserId()) : Guid.NewGuid();
        }

        public bool IsAuthenticated()
        {
            return accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
