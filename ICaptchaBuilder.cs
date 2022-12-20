using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjsz.Captcha
{
    public interface ICaptchaBuilder
    {
        IServiceCollection Services { get; }
    }
}
