using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VuforiaImageTargetManager : MonoBehaviour
{
    //[SerializeField] GameObject textView;
    public void onTargetFound(VideoPlayer player)
    {
        player.Play();
    }

    public void onTargetLost(VideoPlayer player)
    {
        player.Stop();
    }
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
