using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Application.Common.Interface
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
