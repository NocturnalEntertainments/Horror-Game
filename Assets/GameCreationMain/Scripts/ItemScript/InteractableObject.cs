using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    //Here's all the object types that generalizes the types of interactable
    DoorType,
    //DoorType is a type of interactable that requires an animator (ex. Doors,Chest,Cabinets,Buttons and such)
    DestroyType,
    //DestroyType is a type of interactable that gets destroyed when interact (ex. collectibles,keys)   
    NoteType,
    //NoteType is a type of interactable that opens a GUI (ex. notes, books)  
    CollectibleType
    //CollectibleType is a type of interactable that the player equips (ex. skull)
}

public class InteractableObject : MonoBehaviour, IInteractable
{
    //This uses the gamemanager instance         
    public string ObjectName;

    //This is an enum which helps make the interactableObject flexible
    public ObjectType objectType;
    
    //This is for the note thingy if you picked a note type this would appear in the inspector
    public GameObject NoteToOpen;

    private Interactor interactor;
    private Animator doorAnim;

    private void Start() 
    {
        //This code here finds objects that has the interactor script
        interactor = FindObjectOfType<Interactor>();
        SetupComponents();
    }

    public void SetupComponents()
    {    
        string objectName = interactor.GetObjectName(ObjectName);
        
        //This is to get the components of a type such as here I get the component from an animator in order to to access the animator component
        switch (objectType)
        {
            case ObjectType.DoorType:
                doorAnim = GetComponent<Animator>(); 
                break;                           
        }
    }

    public void Interact()
    {
        //I used switch instead in that way it would be easier to read and the codes won't be too long
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
                GameManager.instance.LockAllItemFunction();
                GameManager.instance.UnlockCursor();
                GameManager.instance.LockCameraMovement();  
                GameManager.instance.LockPlayerMovement();              
                NoteToOpen.SetActive(true);
                break;
            case ObjectType.CollectibleType:   
                Debug.Log("Item Equipped");
                break;                                       
        }
    }
}
