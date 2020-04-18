using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingController :DefaultTrackableEventHandler
{


    #region UNITY_MONOBEHAVIOUR_METHODS

    protected override void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected override void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    private void Update()
    {
        
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS




    #region PROTECTED_METHODS

    protected override void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;

            //===to flag the  detection===
            if(gameObject.name != "h_1_ImageTarget"|| gameObject.name != "h_2_ImageTarget"|| gameObject.name != "o_ImageTarget")
            {
                Debug.LogError("please check the name of the image targets");//ignore this error if image targets are not misbehaving
            }

            if(gameObject.name == "h_1_ImageTarget")
            {
                Utility.is_h1_Detected = true;

                //for checking if found h1 and is not collider any more
                if (Utility.is_h1_o_not_colliding_anymore)
                {
                    Utility.has_h1_o_Collided = false;
                }

            }
            if (gameObject.name == "h_2_ImageTarget")
            {
                Utility.is_h2_Detected = true;

                //for checking if found h2 and is not collider any more
                if (Utility.is_h2_o_not_colliding_anymore)
                {
                    Utility.has_h2_o_Collided = false;
                }
            }
            if (gameObject.name == "o_ImageTarget")
            {
                Utility.is_o_Detected = true;
            }


            

        }
    }


    protected override void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;

            //===to flag the  detection===
            if (gameObject.name == "h_1_ImageTarget")
            {
                Utility.is_h1_Detected = false;
            }
            if (gameObject.name == "h_2_ImageTarget")
            {
                Utility.is_h2_Detected = false;
            }
            if (gameObject.name == "o_ImageTarget")
            {
                Utility.is_o_Detected = false;
            }

            //===other utility flags control===
            
            //if (Utility.is_h2oCard_detected == true &&)
        }
    }

    #endregion // PROTECTED_METHODS
}
