﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjsz.Captcha.Core
{
    public interface ICaptchaBuilder
    {
        IServiceCollection Services { get; }
    }
}
