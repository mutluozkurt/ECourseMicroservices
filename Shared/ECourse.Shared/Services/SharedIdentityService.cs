using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECourse.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _htttpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor htttpContextAccessor)
        {
            _htttpContextAccessor = htttpContextAccessor;
        }

        public string GetUserId => _htttpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
