using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;
public class TextureChangeOnTrack : MonoBehaviour
{
    public Material defaultMap;

    public Material map1;
    public string imageTargetExactName1;
    public string displayText1;

    public Material map2;
    public string imageTargetExactName2;
    public string displayText2;

    public TextMeshPro displaybox;

    private Renderer mapRend;
    

    // Start is called before the first frame update


    void Start()
    {
        // displaybox.gameObject.SetActive(false);
        mapRend = GetComponent<Renderer>();
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
        string actual_display_text = "";
        // Iterate through the list of active trackables
        // Debug.Log("List of trackables currently active (tracked): ");
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            // Debug.Log("Trackable: " + tb.TrackableName); 
            if (tb.TrackableName.Contains(imageTargetExactName1))
            {
                disp_habitat1 = true;
                actual_display_text += " " + displayText1 + " ";
            }
            if (tb.TrackableName.Contains(imageTargetExactName2))
            {
                disp_habitat2 = true;
                actual_display_text += " " + displayText2 + " ";
            }
        }
        displaybox.text = actual_display_text;

        // make objects active based on above logic
        if (disp_habitat2)
            mapRend.material = map2;
        if (disp_habitat1)
            mapRend.material = map1;        
        if(!(disp_habitat1 || disp_habitat2))
        {
            displaybox.text = " ";
            mapRend.material = defaultMap;
        }
       
        // make textbox always face the camera 
        displaybox.transform.rotation = Camera.main.transform.rotation;
    }
}
