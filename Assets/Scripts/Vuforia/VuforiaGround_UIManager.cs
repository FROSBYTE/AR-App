using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaGround_UIManager : MonoBehaviour
{
    public void OpenBrowserButtonClicked(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }
}
