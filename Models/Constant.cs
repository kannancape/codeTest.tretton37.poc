using System;
using System.Collections.Generic;
using System.Text;

namespace codeTest.tretton37.poc.Models
{
    internal class Constant
    {
        public const string RegularExpression_FindUrl = "((?<=s*(?:<li>.*?</li>s*)*)<li>.*?</li>)";
        public const string RegularExpression_FindUrlValue = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
        public const string URL = "https://tretton37.com";
    }
}
