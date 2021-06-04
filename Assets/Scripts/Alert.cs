using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Alert : MonoBehaviour
{
    public event Action Targeted = delegate { };
   
    private void OnEnable()
    {
        Targeted?.Invoke();
    }
}
