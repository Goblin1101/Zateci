using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Axe_Event : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    UnityEvent control;

    public void kek()
    {
        control.Invoke();
    }
}
