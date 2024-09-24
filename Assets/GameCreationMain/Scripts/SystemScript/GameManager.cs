using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private bool isPaused = false;    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

#region PlayerFunctions
    //Calling this function will also make the mouse clicking not work idk why T___T
    public void LockPlayer()
    {
        LockCursor();
        LockCameraMovement();
        LockPlayerMovement();    
        LockItemFunction();           
    }

    public void UnlockPlayer()
    {
        UnlockCursor();
        UnlockCameraMovement();
        UnlockPlayerMovement();    
        UnlockItemFunction();      
    }    

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockCameraMovement()
    {
        FirstPersonController playerController = FindObjectOfType<FirstPersonController>();
        if (playerController != null)
        {
            playerController.ToggleCameraMovement(false);
        }
    }

    public void UnlockCameraMovement()
    {
        FirstPersonController playerController = FindObjectOfType<FirstPersonController>();
        if (playerController != null)
        {
            playerController.ToggleCameraMovement(true);
        }
    }

    public void LockPlayerMovement()
    {
        FirstPersonController playerController = FindObjectOfType<FirstPersonController>();
        if (playerController != null)
        {
            playerController.ToggleMovement(false);
        }
    }

    public void UnlockPlayerMovement()
    {
        FirstPersonController playerController = FindObjectOfType<FirstPersonController>();
        if (playerController != null)
        {
            playerController.ToggleMovement(true);
        }
    }    
#endregion

#region ItemFunctions
    public void LockItemFunction()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFunctionality(false);
        }
    }

    public void UnlockItemFunction()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFunctionality(true);
        }
    }    
    #endregion

#region GameFunctions
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        LockPlayer();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false; 
        UnlockPlayer();
    }

    public bool IsGamePaused()
    {
        return isPaused; 
    }
 
#endregion    


}
