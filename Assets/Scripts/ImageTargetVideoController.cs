using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

namespace Vuforia
{

    // SOURCE: https://stackoverflow.com/questions/54614388/how-to-play-a-video-in-a-vuforia-image-target-in-unity
    public class ImageTargetVideoController : MonoBehaviour, ITrackableEventHandler
    {
        private TrackableBehaviour mTrackableBehaviour;
        public UnityEvent myStartEvent;
        public UnityEvent myStopEvent;

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                // When target is found
                myStartEvent.Invoke();
            }
            else
            {
                // When target is lost
                myStopEvent.Invoke();
            }
        }
    }
}