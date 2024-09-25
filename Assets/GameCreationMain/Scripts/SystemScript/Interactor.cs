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
        //We use raycasting here using the "r" variable to check
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            //This gets the name of the object allowing for a flexible access
            if (hitInfo.collider.gameObject.TryGetComponent(out InteractableObject interactableObject))
            {
                    objectNameText.text = GetObjectName(interactableObject.ObjectName);
            }

            //This plays an animation for the UI Interaction
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
            //Pretty much resets the whole thing when the player is no longer interacting with something
            interactionAnim.SetBool("NotInteracting", true);
                objectNameText.text = "";
        }
    }

    public string GetObjectName(string ObjectName)
    {
        return ObjectName;
    }    
}
