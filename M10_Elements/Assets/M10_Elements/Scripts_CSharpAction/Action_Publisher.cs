using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Publisher : MonoBehaviour
{

    public event Action OnActionEvent1;
    public event Action <bool, int> OnActionEvent2;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnActionEvent1?.Invoke();
            OnActionEvent2?.Invoke(true, 5);
        }
    }

}
