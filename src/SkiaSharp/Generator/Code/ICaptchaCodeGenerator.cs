using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjsz.Captcha.Core.Generator.Code
{
    public interface ICaptchaCodeGenerator
    {
        (string renderText, string code) Generate(int length);
    }
}
