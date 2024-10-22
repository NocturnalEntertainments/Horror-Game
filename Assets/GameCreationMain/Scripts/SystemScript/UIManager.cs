using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //This uses the gamemanager instance
    [Header("MainMenu Settings")]      
    public GameObject gameplayOptionsPanel;

    [Header("MainMenu Settings")]       
    public GameObject mainmenuOptionsPanel; 
    //Temporary Fix for start and settings button ui missing it's reference
    public GameObject mainmenuUI;     
    public bool isInMainMenu;   
    public static UIManager instance;
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


    void Update()
    {
        if (isInMainMenu)
        {
            SettingsMainMenuPanelFunction();
            mainmenuUI.SetActive(true);                    
        }
        else
        {
            SettingsGameplayPanelFunction();
            mainmenuUI.SetActive(false);            
        }
    }

#region UI Panels
    public void SettingsGameplayPanelFunction()
    {
        if(!gameplayOptionsPanel.activeSelf)
        {
            //opens the option panel
            if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.IsGamePaused())
            {      
              GameManager.instance.PauseGame();                 
              GameManager.instance.UnlockCursor();                             
              gameplayOptionsPanel.SetActive(true);
            }     
        }   
        else
        {
            //closes the option panel
            if (Input.GetKeyDown(KeyCode.Escape))
            {
              GameManager.instance.UnlockFlashlightItemFunction();                               
              GameManager.instance.ResumeGame();                               
              GameManager.instance.LockCursor();                  
              gameplayOptionsPanel.SetActive(false);
            }                 
        }
    }

    public void SettingsMainMenuPanelFunction()
    {
        if(!mainmenuOptionsPanel.activeSelf)
        {
            //opens the option panel
            if (Input.GetKeyDown(KeyCode.Escape))
            {                        
              mainmenuOptionsPanel.SetActive(true);
            }     
        }   
        else
        {
            //closes the option panel
            if (Input.GetKeyDown(KeyCode.Escape))
            {                                        
              mainmenuOptionsPanel.SetActive(false);
            }                 
        }
    }    
#endregion

#region UI Button Functions
    public void PlayGame()
    {
        SceneManager.LoadScene("TestScene");      
        isInMainMenu = false;          
    }

    public void GoToMainMenu()
    {
        gameplayOptionsPanel.SetActive(false);
        GameManager.instance.UnlockCursor();    
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ResumeGame();      
        isInMainMenu = true;                           
    }   
    #endregion 
}
