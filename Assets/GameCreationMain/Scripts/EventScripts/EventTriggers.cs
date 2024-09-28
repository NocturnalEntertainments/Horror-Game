using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum TriggerType
{
    ShowAllTypes,
    ShowPlayerEntersType,
    ShowPlayerExitsType,
    ShowPlayerLooksAtType,
    ShowPlayerStopsLookingType
}

public class EventTriggers : MonoBehaviour
{

    public TriggerType triggerType;

    [Header("Restrictions Booleans")]        
    //If you're using the event trigger functions please tick this on if not tick this off
    [Header("Only Check this if you're using EventTriggerFunctions")]        
    public bool usesGameManager;
    public bool functionHasTimer;       
    
    [Header("Function Intervals")]     
    public float FunctionDelay;
    public float FunctionDuration;    

    [Header("If player enters the trigger object this happens")]    
    public UnityEvent TriggerEnter;    
    [Header("If player exits the trigger object this happens")]        
    public UnityEvent TriggerExit;      
    [Header("If player looks at the trigger object this happens")]      
    public UnityEvent MouseEnter;      
    [Header("If player stops looks at the trigger object this happens")]      
    public UnityEvent MouseExits;          

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (functionHasTimer && !usesGameManager)
            {
                StartCoroutine(HandleEventWithTimer());
            }
            else
            {
                TriggerEnter.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerExit.Invoke();
        }
    }    

    private void OnMouseEnter() 
    {
        MouseEnter.Invoke();        
    }

    private void OnMouseExit() 
    {
        MouseExits.Invoke();        
    }

    // General function to handle locking/unlocking with timer
    private void HandleGameFunction(UnityAction lockAction, UnityAction unlockAction)
    {
        if (functionHasTimer)
        {
            StartCoroutine(GameFunctionWithTimer(lockAction, unlockAction, FunctionDelay, FunctionDuration));
        }
        else
        {
            lockAction.Invoke();
        }
    }

    #region PlayerFunctions
    public void LockAllTrigger() => HandleGameFunction(GameManager.instance.LockPlayer, GameManager.instance.UnlockPlayer);
    public void UnlockAllTrigger() => HandleGameFunction(GameManager.instance.UnlockPlayer, GameManager.instance.LockPlayer);
    public void LockCursorTrigger() => HandleGameFunction(GameManager.instance.LockCursor, GameManager.instance.UnlockCursor);
    public void UnlockCursorTrigger() => HandleGameFunction(GameManager.instance.UnlockCursor, GameManager.instance.LockCursor);
    public void LockCameraMovementTrigger() => HandleGameFunction(GameManager.instance.LockCameraMovement, GameManager.instance.UnlockCameraMovement);
    public void UnlockCameraMovementTrigger() => HandleGameFunction(GameManager.instance.UnlockCameraMovement, GameManager.instance.LockCameraMovement);
    public void LockPlayerMovementTrigger() => HandleGameFunction(GameManager.instance.LockPlayerMovement, GameManager.instance.UnlockPlayerMovement);
    public void UnlockPlayerMovementTrigger() => HandleGameFunction(GameManager.instance.UnlockPlayerMovement, GameManager.instance.LockPlayerMovement);
    #endregion

    #region ItemFunctions
    public void LockItemFunctionTrigger() => HandleGameFunction(GameManager.instance.LockAllItemFunction, GameManager.instance.UnlockAllItemFunction);
    public void UnlockItemFunctionTrigger() => HandleGameFunction(GameManager.instance.UnlockAllItemFunction, GameManager.instance.LockAllItemFunction);
    #endregion

    // Coroutine for non-GameManager events with delay and duration
    private IEnumerator HandleEventWithTimer()
    {
        yield return new WaitForSeconds(FunctionDelay);
        TriggerEnter?.Invoke();
        yield return new WaitForSeconds(FunctionDuration);
        TriggerEnter?.Invoke();
    }

    // Coroutine for GameManager functions with delay and duration
    private IEnumerator GameFunctionWithTimer(UnityAction lockAction, UnityAction unlockAction, float delay, float duration)
    {
        yield return new WaitForSeconds(delay);
        
        GameManager.instance.isPlayingEvent = true;
        lockAction?.Invoke();

        yield return new WaitForSeconds(duration);

        unlockAction?.Invoke();
        GameManager.instance.isPlayingEvent = false;
    }
}
