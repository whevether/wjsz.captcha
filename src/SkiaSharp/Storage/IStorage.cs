﻿using System;

namespace Wjsz.Captcha.Core.Storage
{
    public interface IStorage
    {
        void Set(string key, string value, DateTimeOffset absoluteExpiration);

        string Get(string key);

        void Remove(string key);
    }
}