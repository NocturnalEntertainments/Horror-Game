using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
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
        OpenSettingsPanel();
    }

    public void OpenSettingsPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
              GameManager.instance.UnlockCursor();                
              optionsPanel.SetActive(true);
        }        
    }

    public void CloseSettingsPanel()
    {
              GameManager.instance.LockCursor();                
              optionsPanel.SetActive(false);
    }    
}
