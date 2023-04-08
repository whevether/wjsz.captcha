using Wjsz.Captcha.Core.Generator;
using Wjsz.Captcha.Core.Generator.Image.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjsz.Captcha.Core.Generator.Image
{
    public interface ICaptchaImageOptionBuilder
    {
        CaptchaImageGeneratorOption Build();
    }
}
