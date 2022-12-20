using Wjsz.Captcha.Generator;
using Wjsz.Captcha.Generator.Image.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjsz.Captcha.Generator.Image
{
    public interface ICaptchaImageOptionBuilder
    {
        CaptchaImageGeneratorOption Build();
    }
}
