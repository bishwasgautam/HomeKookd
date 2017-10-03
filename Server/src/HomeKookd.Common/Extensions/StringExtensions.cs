using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeKookd.Common.Extensions
{
    public static class StringExtensions
    {
        //src: https://stackoverflow.com/questions/1450774/splitting-a-string-into-chunks-of-a-certain-size
        public static IEnumerable<string> SplitIntoChunks(this string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
