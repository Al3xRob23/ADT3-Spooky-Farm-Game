using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteractable : MonoBehaviour
{
    private Material defaultMaterial;
    public Material highlightedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //defaultMaterial = MeshRenderer
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        Debug.Log("Chest");
        GetComponent<MeshRenderer>().material = highlightedMaterial;
    }
    public void UnHighlight()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
