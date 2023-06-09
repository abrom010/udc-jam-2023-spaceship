using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    [SerializeField] protected bool hasSecondaryInteraction;

    private void Start()
    {
        
    }

    public virtual void Interact(bool primary)
    {
        
    }

    public virtual void Highlight()
    {
        highlight.SetActive(true);
    }

    public virtual void ResetHighlight()
    {
        highlight.SetActive(false);
    }
}
