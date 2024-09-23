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
    [Header("General Settings")]        
    public string ObjectName;
    public ObjectType objectType;

    [Header("(If NoteType) Note Settings")]    
    public GameObject NoteToOpen;

    private Interactor interactor;
    private Animator doorAnim;

    private void Start() 
    {
        interactor = FindObjectOfType<Interactor>(); // Initialize interactor
        SetupComponents();
    }

    public void SetupComponents()
    {    
        string objectName = interactor.GetObjectName(ObjectName);

        switch (objectType)
        {
            case ObjectType.DoorType:
                doorAnim = GetComponent<Animator>(); // Initialize doorAnim
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
                GameManager.instance.UnlockCursor();
                NoteToOpen.SetActive(true);
                break;                                
        }
    }
}
