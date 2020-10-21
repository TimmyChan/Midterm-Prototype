using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Show_if_card_tracked : MonoBehaviour
{
    private GameObject habitat; // object to be a sphere layering on top of the lowpoly earth
    public Material newMaterialRef; // public variable to allow for quick switching of materials for habitat
    // Start is called before the first frame update
    void Start()
    {
        habitat = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // Make habitat a child of the image target
        // https://developer.vuforia.com/forum/unity-extension-technical-discussion/creating-child-object-image-targets-runtime
        habitat.transform.parent = this.gameObject.transform;

        // Get the renderer for the ball
        Renderer habitat_renderer = habitat.GetComponent<Renderer>();
        // use renderer to set material 
        if (habitat_renderer != null)
        { 
            habitat_renderer.material = newMaterialRef; 
        }

        // size then position
        habitat.transform.localScale = new Vector3(2.1f, 2.1f, 2.1f); 
        habitat.transform.localPosition = new Vector3(0, 1.0f, 0);

        // habitat.SetActive(false);
        // set name and position of sphere
        habitat.name = "Habitat for White Sharks";
    }

    // Update is called once per frame
    void Update()
    {
    }
}