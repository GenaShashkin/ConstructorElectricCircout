using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeButtonEvents : MonoBehaviour
{

    public void InvokeAllEvents(Button button)
    {
        button.onClick.Invoke();
    }
}
