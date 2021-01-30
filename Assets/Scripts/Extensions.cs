using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 


    public static partial class Extensions
    {
        /// <summary>
        /// Returns a random value from this collection. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static T GetRandom<T>(this IEnumerable<T> ts)
        {
           return ts.ElementAt(UnityEngine.Random.Range(0, ts.Count()));   
        }
    }

