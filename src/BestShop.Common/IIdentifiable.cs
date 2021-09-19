using System;
using System.Collections.Generic;
using System.Text;

namespace BetShop.Common
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
