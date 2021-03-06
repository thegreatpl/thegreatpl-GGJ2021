﻿using Assets.Scripts.Entities.Enums;
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
        if (ts.Count() < 1)
            return default(T); 

        return ts.ElementAt(UnityEngine.Random.Range(0, ts.Count()));
    }

    /// <summary>
    /// Gets a random direction. 
    /// </summary>
    /// <returns></returns>
    public static Direction RandomDiraction()
    {
        return (Direction)UnityEngine.Random.Range(0, 5); 
    }

    /// <summary>
    /// Checks to see if the collection contains all items from the other collection. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool ContainsAllItems<T>(this IEnumerable<T> a, IEnumerable<T> b)
    {
        return !b.Except(a).Any();
    }
}

