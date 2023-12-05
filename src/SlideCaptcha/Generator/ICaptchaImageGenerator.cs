using System;
using System.Collections.Generic;
using System.Text;

namespace SlideCaptcha.Core.Generator
{
    public interface ICaptchaImageGenerator
    {
        CaptchaImageData Generate();
    }
}
