using System;
using UnityEngine;

public class LandingCheckEventContainer : MonoBehaviour
{
    public event Action OnLaunchEvent;
    public event Action OnLandingEvent;
    private bool isLanding;

    private void Start()
    {
        isLanding = true;
    }

    public void Update()
    {
        if (transform.position.y > 2.5f && isLanding)
        {
            CallOnLaunchEvent();
            isLanding = false;
        }

        else if (transform.position.y <= 2.5f && !isLanding)
        {
            CallOnLandingEvent();
            isLanding = true;
        }
    }

    public void CallOnLaunchEvent()
    {
        OnLaunchEvent?.Invoke();
    }

    public void CallOnLandingEvent()
    {
        OnLandingEvent?.Invoke();
    }
}