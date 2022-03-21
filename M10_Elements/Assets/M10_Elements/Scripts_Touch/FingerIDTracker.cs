using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerIDTracker : MonoBehaviour
{
    public int fingerID;
    public UnityEvent onBegan;
    public UnityEvent onStationary;
    public UnityEvent onMoved;
    public UnityEvent onEnded;
    public UnityEvent onCancel;

    private void Update()
    {
        int touchCount = Input.touchCount;
        for (int i=0; i<touchCount; i++)
        {
            if(Input.GetTouch(i).fingerId == fingerID)
            {
                ProcessPhase(Input.GetTouch(i).phase);
            }
        }
    }

    public void ProcessPhase(TouchPhase phase)
    {
        switch (phase)
        {
            case TouchPhase.Began:
                onBegan?.Invoke();
                break;
            case TouchPhase.Stationary:
                onStationary?.Invoke();
                break;
            case TouchPhase.Moved:
                onMoved?.Invoke();
                break;
            case TouchPhase.Ended:
                onEnded?.Invoke();
                break;
            case TouchPhase.Canceled:
                onCancel?.Invoke();
                break;
        }
    }
}
