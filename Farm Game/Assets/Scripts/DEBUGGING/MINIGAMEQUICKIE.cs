using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("QUICKFIX"))]
public class MINIGAMEQUICKIE : ScriptableObject
{
    public bool FIX = false;

    public void SetFIX(bool x)
    {
        FIX = x;
    }
}
