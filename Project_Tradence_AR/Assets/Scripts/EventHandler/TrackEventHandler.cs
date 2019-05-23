using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class TrackEventHandler : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    public VideoPlayer videoCanvas;
    public VideoPlayer videoTracker;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        videoCanvas.Stop();
        videoTracker.Stop();
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    protected virtual void OnTrackingFound()
    {
        // Was already successfully done
        videoCanvas.Play();
        videoTracker.Play();
    }


    protected virtual void OnTrackingLost()
    {
        // Was already successfully done
        videoCanvas.Pause();
        videoTracker.Pause();
    }
}