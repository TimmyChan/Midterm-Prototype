﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Show_if_card_tracked : MonoBehaviour
{
    private GameObject habitat1; // object to be a sphere layering on top of the lowpoly earth
    private GameObject habitat2;

    public Material newMaterialRef1; // public variable to allow for quick switching of materials for habitat
    public string imageTargetName1; // image target name, must be precise
    public string habitatName1; // habitat name displayed?

    public Material newMaterialRef2;
    public string imageTargetName2;
    public string habitatName2;

    // Start is called before the first frame update
    void Start()
    {
        habitat1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        habitat2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // Make habitat a child of the image target
        // https://developer.vuforia.com/forum/unity-extension-technical-discussion/creating-child-object-image-targets-runtime
        habitat1.transform.parent = this.gameObject.transform;
        habitat2.transform.parent = this.gameObject.transform;

        // Get the renderer for the ball
        Renderer habitat_renderer1 = habitat1.GetComponent<Renderer>();
        Renderer habitat_renderer2 = habitat2.GetComponent<Renderer>();
        // use renderer to set material 
        if (habitat_renderer1 != null)
            habitat_renderer1.material = newMaterialRef1;
        if (habitat_renderer2 != null)
            habitat_renderer2.material = newMaterialRef2;


        // size then position
        habitat1.transform.localScale = new Vector3(2.1f, 2.1f, 2.1f); 
        habitat1.transform.localPosition = new Vector3(0, 1.0f, 0);
        habitat2.transform.localScale = new Vector3(2.1f, 2.1f, 2.1f);
        habitat2.transform.localPosition = new Vector3(0, 1.0f, 0);

        // set name 
        habitat1.name = habitatName1;
        habitat2.name = habitatName2;

        habitat1.SetActive(false);
        habitat2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Modification from https://developer.vuforia.com/forum/faq/unity-how-do-i-get-list-active-trackables
        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

    

        // assume the card we want is not in tracked
        // bool to capture if we should display the habitat
        bool disp_habitat1 = false;
        bool disp_habitat2 = false;
        
        // Iterate through the list of active trackables
        Debug.Log("List of trackables currently active (tracked): ");
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("Trackable: " + tb.TrackableName);
            if(tb.TrackableName.Contains(imageTargetName1))
                disp_habitat1 = true;
            if (tb.TrackableName.Contains(imageTargetName2))
                disp_habitat2 = true;
        }
        habitat1.SetActive(disp_habitat1);
        habitat2.SetActive(disp_habitat2);
    }
}