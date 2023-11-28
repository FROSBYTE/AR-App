using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VuforiaManager : MonoBehaviour
{
    //[SerializeField] GameObject textView;
    public void onTargetFound(VideoPlayer player)
    {
        player.Play();
        //textView.SetActive(false);
    }

    public void onTargetLost(VideoPlayer player)
    {
        player.Stop();
        //textView.SetActive(true);
    }
}
