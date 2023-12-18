using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlaygroundmanager : MonoBehaviour
{
    public void OpenBrowserButtonClicked(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }
}
