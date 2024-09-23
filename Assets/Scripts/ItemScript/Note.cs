using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public void closeNote()
    {
        Debug.Log("Note Closed");        
        GameManager.instance.LockCursor();
        gameObject.SetActive(false);
    }
}
