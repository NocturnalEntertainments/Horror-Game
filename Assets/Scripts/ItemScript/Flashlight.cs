using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public Animator anim;
    private bool isOn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActivateAndDeactivateFlashlight();
        }
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
