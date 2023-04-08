using Wjsz.Captcha.Core.Generator.Code;
using Wjsz.Captcha.Core.Generator.Image;
using Wjsz.Captcha.Core.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjsz.Captcha.Core
{
    public class DefaultCaptcha : ICaptcha
    {
        protected CaptchaOptions _options;
        protected IStorage _storage;
        protected ICaptchaCodeGenerator _captchaCodeGenerator;
        protected ICaptchaImageGenerator _captchaImageGenerator;

        public DefaultCaptcha(IOptionsSnapshot<CaptchaOptions> options, IStorage storage)
        {
            _options = options.Value;
            _storage = storage;

            ChangeOptions(_options);

            _captchaCodeGenerator = new DefaultCaptchaCodeGenerator(_options.CaptchaType);
            _captchaImageGenerator = new DefaultCaptchaImageGenerator();
        }

        // ѡ�����
        protected virtual void ChangeOptions(CaptchaOptions options)
        { 
            
        }

        /// <summary>
        /// ������֤��
        /// </summary>
        /// <param name="captchaId">��֤��id</param>
        /// <param name="expirySeconds">����ʱ�䣬δ�趨��ʹ������ʱ��</param>
        /// <returns></returns>
        public virtual CaptchaData Generate(string captchaId, int? expirySeconds = null)
        {
            var (renderText, code) = _captchaCodeGenerator.Generate(_options.CodeLength);
            var image = _captchaImageGenerator.Generate(renderText, _options.ImageOption);
            expirySeconds = expirySeconds.HasValue ? expirySeconds.Value : _options.ExpirySeconds;
            _storage.Set(captchaId, code, DateTime.Now.AddSeconds(expirySeconds.Value).ToUniversalTime());

            return new CaptchaData(captchaId, code, image);
        }

        /// <summary>
        /// У��
        /// </summary>
        /// <param name="captchaId">��֤��id</param>
        /// <param name="code">�û��������֤��</param>
        /// <param name="removeIfSuccess">У��ɹ�ʱ�Ƿ��Ƴ�����(���ڶ����֤)</param>
        /// <returns></returns>
        public virtual bool Validate(string captchaId, string code, bool removeIfSuccess = true)
        {
            var val = _storage.Get(captchaId);
            var comparisonType = _options.IgnoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
            var success = !string.IsNullOrWhiteSpace(code) && 
                          !string.IsNullOrWhiteSpace(val) && 
                          string.Equals(val, code, comparisonType);

            if (!success || (success && removeIfSuccess))
            {
                _storage.Remove(captchaId);
            }

            return success;
        }
    }
}