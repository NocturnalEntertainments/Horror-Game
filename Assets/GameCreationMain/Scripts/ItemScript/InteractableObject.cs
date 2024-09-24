using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    DoorType,
    DestroyType,
    NoteType
}

public class InteractableObject : MonoBehaviour, IInteractable
{
    //This uses the gamemanager instance    
    [Header("General Settings")]        
    public string ObjectName;
    public ObjectType objectType;

    [Header("(If NoteType) Note Settings")]    
    public GameObject NoteToOpen;

    private Interactor interactor;
    private Animator doorAnim;

    private void Start() 
    {
        interactor = FindObjectOfType<Interactor>();
        SetupComponents();
    }

    public void SetupComponents()
    {    
        string objectName = interactor.GetObjectName(ObjectName);

        switch (objectType)
        {
            case ObjectType.DoorType:
                doorAnim = GetComponent<Animator>(); 
                break;                           
        }
    }

    public void Interact()
    {
        switch (objectType)
        {
            case ObjectType.DoorType:
                Debug.Log("Door Open");
                break;
            case ObjectType.DestroyType:
                Debug.Log("Destroyed");
                Destroy(gameObject);
                break;
            case ObjectType.NoteType:
                Debug.Log("Note Open");
                GameManager.instance.LockItemFunction();
                GameManager.instance.UnlockCursor();
                GameManager.instance.LockCameraMovement();  
                GameManager.instance.LockPlayerMovement();              
                NoteToOpen.SetActive(true);
                break;                                
        }
    }
}
