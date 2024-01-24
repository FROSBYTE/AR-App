using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_PlaneDetection : MonoBehaviour
{
    [SerializeField] TransitionSettings _transition;

    public void OpenBrowserButtonClicked(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }

    public void LoadScene()
    {
        TransitionManager.Instance().Transition("Menu", _transition, 0);
    }
}
