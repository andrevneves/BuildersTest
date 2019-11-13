using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.WebApi.Domain.Utils
{
    public class Text
    {
        public static bool IsPalindrome(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            var reversed = word.ToCharArray();
            Array.Reverse(reversed);

            return string
                .Join(string.Empty, reversed)
                .Equals(word, StringComparison.OrdinalIgnoreCase);
        }
    }
}
