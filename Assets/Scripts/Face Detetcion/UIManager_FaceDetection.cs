using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_FaceDetection : MonoBehaviour
{
    public void OpenBrowserButtonClicked(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }
}
