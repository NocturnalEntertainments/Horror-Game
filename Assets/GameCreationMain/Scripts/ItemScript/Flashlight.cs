using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public Light flashlight;
    public Animator anim;
    private bool canFlashlightFunction = true;
    private bool isOn;

    private void Update()
    {
        if (canFlashlightFunction && !GameManager.instance.IsGamePaused())
        {
          if (Input.GetMouseButtonDown(0))
          {
              ActivateAndDeactivateFlashlight();
          }
        }
    }

    public void ToggleFunctionality(bool canFunction)
    {
        canFlashlightFunction = canFunction;
    }
    

    private void ActivateAndDeactivateFlashlight()
    {
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
