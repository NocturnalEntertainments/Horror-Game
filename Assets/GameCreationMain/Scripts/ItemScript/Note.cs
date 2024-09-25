using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //This uses the gamemanager instance

    private void Update()
    {
        if (UIManager.instance.gameplayOptionsPanel.activeSelf)
        {
            closeNote();
        }
    }

    public void closeNote()
    {

        if (UIManager.instance.gameplayOptionsPanel.activeSelf)
        {
            gameObject.SetActive(false);            
        }
        else
        {
            //When the note is closes it access various functions in the gameManager
            Debug.Log("Note Closed");        
            GameManager.instance.LockCursor();
            GameManager.instance.UnlockItemFunction();           
            GameManager.instance.UnlockPlayerMovement();      
            GameManager.instance.UnlockCameraMovement();               
            gameObject.SetActive(false);
        }        
    }

}
