using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINIGAMEQUICKIE : MonoBehaviour
{
    public bool FIX;

    public void Switch()
    {
        if (FIX)
        {
            FIX = false;
        }
        else
        {
            FIX = true;
        }
    }
}
