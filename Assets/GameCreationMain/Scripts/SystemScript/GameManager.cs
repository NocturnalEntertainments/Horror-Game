using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //This help to pause the game
    private bool isPaused = false;    

    //This bool is important as it acts as a restriction in that way when an event is playing
    //Like if the player touches a trigger and he cant move this make it so that pausing the game won't help
    public bool isPlayingEvent;
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
        LockAllItemFunction();           
    }

    public void UnlockPlayer()
    {
        UnlockCursor();
        UnlockCameraMovement();
        UnlockPlayerMovement();    
        UnlockPlayerMovement();      
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

    public void LockAllItemFunction()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFlashlightFunctionality(false);
        }
    }

    public void UnlockAllItemFunction()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFlashlightFunctionality(true);
        }
    }    

#region FlashlightFunctions
    public void LockFlashlightItemFunction()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFlashlightFunctionality(false);
        }
    }

    public void UnlockFlashlightItemFunction()
    {
        Flashlight itemState = FindObjectOfType<Flashlight>();
        if (itemState != null)
        {
            itemState.ToggleFlashlightFunctionality(true);
        }
    }    

    public void EquipFlashlight()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFlashlightEquipState(true);
        }
    }    
    public void UnequipFlashlight()
    {
        Flashlight itemFunction = FindObjectOfType<Flashlight>();
        if (itemFunction != null)
        {
            itemFunction.ToggleFlashlightEquipState(false);
        }
    }        
    #endregion    
    #endregion

#region GameFunctions
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        if (!isPlayingEvent)
        {
          LockPlayer();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false; 

        if (!isPlayingEvent)
        {
          UnlockPlayer();
        }        
    }

    public bool IsGamePaused()
    {
        return isPaused; 
    }

    public bool IsGameEventPlaying()
    {
        return isPlayingEvent; 
    }    
 
#endregion    


}
