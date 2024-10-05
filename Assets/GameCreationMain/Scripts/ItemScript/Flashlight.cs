using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public Light flashlight;
    public Animator anim;
    private bool canFlashlightFunction = true;
    private bool isFlaslightEquipped = true;    
    private bool isOn;

    private void Update()
    {
        //We simply call the function here with some restrictions
        if (canFlashlightFunction && !GameManager.instance.IsGamePaused())
        {
          if (Input.GetMouseButtonDown(0))
          {
              ActivateAndDeactivateFlashlight();
          }
        }
    }

    public void ToggleFlashlightFunctionality(bool canFunction)
    {
        //This is important as it would help the gameManager to access the functionality of the flashlight
        canFlashlightFunction = canFunction;
    }

    public void ToggleFlashlightEquipState(bool isEquipped)
    {     
        //This is important as it would help the gameManager to access the functionality of the flashlight
        isFlaslightEquipped = isEquipped;
                UpdateFlashlightState();   
    }    
    
    private void UpdateFlashlightState()
    {
        if (isFlaslightEquipped)
        {
            anim.SetBool("Unequipped",false);       
        }
        else
        {
            anim.SetBool("Unequipped",true);
        }
    }

    private void ActivateAndDeactivateFlashlight()
    {
        //This turns off/on the light as well as playing an animation that uses the trigger "On&Off"
        isOn = !isOn;
        if (flashlight != null)
        {
            flashlight.enabled = isOn;
        }

        if (anim != null)
        {
            anim.SetTrigger("On&Off");
        }
    }
}
