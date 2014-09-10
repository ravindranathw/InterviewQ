using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQ.Business.Util
{
    public static class ExtentionMethods
    {
        public static decimal PercentageOf(this int percent, decimal number)
        {
            return number * percent / 100;
        }

        public static decimal RoundedPercentageOf(this int percent, decimal number, MidpointRounding rounding)
        {
            return Math.Round(percent.PercentageOf(number), rounding);
        }

        public static int FloorPercentageOf(this int percent, decimal number)
        {
            return Convert.ToInt32(Math.Floor(percent.PercentageOf(number)));
        }


        //public static IEnumerable<TSource> TakeRandom<TSource>(this IEnumerable<TSource> source, int count)
        //{
        //    return source.Shuffle().Take(count);
        //}

        /// <summary>
        /// Do a Fisher-Yates Shuffle on a given IEnumerable collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> source)
        {
            var random = new Random();
            var shuffleSource = source.ToArray();

            for (int i = shuffleSource.Length; i > 1; i--)
            {
                var randomIndex = random.Next(i);

                TSource tmp = shuffleSource[randomIndex];
                shuffleSource[randomIndex] = shuffleSource[i - 1];
                shuffleSource[i - 1] = tmp;
            }
            return shuffleSource;
        }
    }
}
