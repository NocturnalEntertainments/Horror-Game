using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ButtonTweens : MonoBehaviour
{
    private Vector3 origPos;
    private RectTransform rectTransform;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        origPos = rectTransform.localPosition;
    }

    public void showSettingsPanel()
    {
        rectTransform.DOLocalMove(new Vector3(origPos.x, origPos.y, origPos.z - 2), 0.5f).SetEase(Ease.InOutBack);
    }

}
