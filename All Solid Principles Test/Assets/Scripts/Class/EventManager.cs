using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action Takehit;
    public static void Hitting()
    {
        Takehit?.Invoke();
    }
}
