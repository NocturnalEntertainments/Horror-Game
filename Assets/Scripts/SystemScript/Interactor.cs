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
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactRange, Color.red, 1.0f);
        
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out InteractableObject interactableObject))
            {
                    objectNameText.text = GetObjectName(interactableObject.ObjectName);
            }

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
            interactionAnim.SetBool("NotInteracting", true);
                objectNameText.text = "";
        }
    }

    public string GetObjectName(string ObjectName)
    {
        return ObjectName;
    }    
}
