using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

interface IInteractable {
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public GameObject interactionCanvas;
    public float interactRange = 3f;
    public TextMeshProUGUI objectNameText;
    private Camera playerCamera;
    private Animator interactionAnim;
    private Transform highlight;
    private RaycastHit raycastHit;
    private float raycastCooldown = 0.1f;
    private float timeSinceLastRaycast = 0f;

    void Start()
    {
        playerCamera = GetComponent<Camera>();
        interactionAnim = interactionCanvas.GetComponent<Animator>();
        objectNameText = interactionCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        timeSinceLastRaycast += Time.deltaTime;

        if (timeSinceLastRaycast >= raycastCooldown)
        {
           RaycastInteraction();
           timeSinceLastRaycast = 0f;
        }
    }

    void RaycastInteraction()
    {
    // We use raycasting here using the "r" variable to check
    Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
    
    if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
    {
        // Check if the object hit by the ray has an InteractableObject component
        if (hitInfo.collider.gameObject.TryGetComponent(out InteractableObject interactableObject))
        {
            // Display the object's name and play the interaction animation
            objectNameText.text = GetObjectName(interactableObject.ObjectName);
            interactionAnim.SetBool("NotInteracting", false);
            Transform hitTransform = hitInfo.transform;
            HighlightObject(hitTransform);

            if (highlight == hitTransform && Input.GetKeyDown(KeyCode.E))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
        else
        {
            // Reset interaction when the player is no longer interacting with something
            HighlightObject(null);            
            interactionAnim.SetBool("NotInteracting", true);
            objectNameText.text = "";
        }
    }
    else
    {
        // Ensure everything is reset if the raycast doesn't hit anything
        HighlightObject(null);     
        interactionAnim.SetBool("NotInteracting", true);
        objectNameText.text = "";
    }
    }

    public string GetObjectName(string ObjectName)
    {
        return ObjectName;
    }    

    public void HighlightObject(Transform newHighlight)
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
        }

        if (newHighlight != null)
        {
            highlight = newHighlight;

            if (highlight.CompareTag("Interactable"))
            {
                Outline outline = highlight.gameObject.GetComponent<Outline>();
                if (outline != null)
                {
                    outline.enabled = true;
                }
                else
                {
                    outline = highlight.gameObject.AddComponent<Outline>();
                    outline.OutlineColor = Color.white;
                    outline.OutlineWidth = 8.0f;
                    outline.enabled = true;
                }
            }
        }
        else
        {
            highlight = null;
        }
    }    
}
