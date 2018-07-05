using System;
using System.Collections.Generic;
using System.Text;

namespace ISLambdaCSharp.Domain.Models
{
    [Flags]
    public enum GamePlatform
    {
        PS4,
        PC,
        Both=PS4 | PC
    }
}
