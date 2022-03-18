using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvent_Publisher : MonoBehaviour
{
    public UnityEvent OnThisUnityEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            OnThisUnityEvent?.Invoke();
        }
    }
}
