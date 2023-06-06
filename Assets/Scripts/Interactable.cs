using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] bool hasSecondaryInteraction;

    [SerializeField] private Renderer renderer;

    private void Start()
    {
        
    }

    public virtual void Interact(bool primary)
    {
        
    }

    public void Highlight()
    {
        renderer.material = highlightMaterial;
    }

    public void ResetHighlight()
    {
        renderer.material = originalMaterial;
    }
}
