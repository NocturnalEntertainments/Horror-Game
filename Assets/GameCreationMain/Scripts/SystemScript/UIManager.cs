using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //This uses the gamemanager instance
    [Header("MainMenu Settings")]      
    public GameObject gameplayOptionsPanel;

    [Header("MainMenu Settings")]       
    public GameObject mainmenuOptionsPanel; 
    public GameObject mainmenuUI;     
    public bool isInMainMenu;   
    public static UIManager instance;

    [Header("Loading Settings")]   
    public GameObject LoadingScreen;

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
            if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.IsGamePaused())
            {      
                GameManager.instance.PauseGame();                 
                GameManager.instance.UnlockCursor();                             
                gameplayOptionsPanel.SetActive(true);
            }     
        }   
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instance.RightHanditemsToUnlock(0);                               
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
            if (Input.GetKeyDown(KeyCode.Escape))
            {                        
                mainmenuOptionsPanel.SetActive(true);
            }     
        }   
        else
        {
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
        SpecificLoadScene(1);      
        isInMainMenu = false;          
    }

    public void GoToMainMenu()
    {
        gameplayOptionsPanel.SetActive(false);
        GameManager.instance.UnlockCursor();    
        SpecificLoadScene(0);
        GameManager.instance.ResumeGame();      
        isInMainMenu = true;                           
    }   
    #endregion 

    #region Loading Screen UI  

    public void SpecificLoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    public void NextLoadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneAsync(currentSceneIndex + 1));
    }    

    IEnumerator LoadSceneAsync(int sceneId)
    {
        // Start loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true);

        // Wait until the scene is fully loaded
        while (!operation.isDone)
        {
            yield return null; // Wait for the next frame
        }

        // Deactivate the loading screen after the scene has loaded
        LoadingScreen.SetActive(false);
    }
    #endregion 
}
