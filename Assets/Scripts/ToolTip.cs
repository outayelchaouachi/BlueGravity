using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public static ToolTip Instance;
    // Get references to UI elements in the item UI prefab
    TextMeshProUGUI toolTipText;
    RectTransform backgroundRectTransform;

    private void Awake()
    {
        Instance = this;
        toolTipText= transform.Find("Text").GetComponent<TextMeshProUGUI>();
        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        ShowToolTip("Othellos says hi!");
    }

    private void Update()
    {
        FixTooltipToMouseCursor();
    }

    private void FixTooltipToMouseCursor()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;
    }

    //Show the tooltip a custom text
    private void ShowToolTip(string toolTipstring)
    {
        gameObject.SetActive(true);

        toolTipText.text = toolTipstring;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth+textPaddingSize*2f, toolTipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta= backgroundSize;
        StartCoroutine(HideTooltipAfterDelay(2f));
    }

    public void ShowToolTip_Static(string toolTipstring)
    {
        ShowToolTip(toolTipstring);
    }

    // Coroutine to deactivate the tooltip after a delay
    private IEnumerator HideTooltipAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

}
