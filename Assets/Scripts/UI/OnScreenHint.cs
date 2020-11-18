using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnScreenHint : MonoBehaviour
{
    public TextMeshProUGUI label;

    //TODO make animation instead of coroutines
    public void ShowHint(string hint)
    {
        transform.SetAsLastSibling();
        label.text = hint;
        StartCoroutine(HideAfterDelay(4f));
    }

    private IEnumerator HideAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        label.text = "";
    }
}
