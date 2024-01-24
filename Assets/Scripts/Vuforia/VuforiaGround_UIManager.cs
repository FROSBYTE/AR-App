using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaGround_UIManager : MonoBehaviour
{
    public void OpenBrowserButtonClicked(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }

    [SerializeField] TransitionSettings _transition;

    public void LoadScene()
    {
        TransitionManager.Instance().Transition("Menu", _transition, 0);
    }
}
