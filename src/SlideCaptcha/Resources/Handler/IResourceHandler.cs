using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SlideCaptcha.Core.Resources.Handler
{
    public interface IResourceHandler
    {
        bool CanHandle(string handlerType);
        byte[] Handle(Resource resource);
    }
}
