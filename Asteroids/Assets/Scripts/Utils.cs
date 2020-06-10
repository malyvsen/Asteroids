using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float Mod(float a, float m)
    {
        return ((a % m) + m) % m;
    }
}