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

    void Start()
    {
        playerCamera = GetComponent<Camera>();
        interactionAnim = interactionCanvas.GetComponent<Animator>();
        objectNameText = interactionCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        RaycastInteraction();
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
            if (Input.GetKeyDown(KeyCode.E))
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
            interactionAnim.SetBool("NotInteracting", true);
            objectNameText.text = "";
        }
    }
    else
    {
        // Ensure everything is reset if the raycast doesn't hit anything
        interactionAnim.SetBool("NotInteracting", true);
        objectNameText.text = "";
    }
    }

    public string GetObjectName(string ObjectName)
    {
        return ObjectName;
    }    
}
