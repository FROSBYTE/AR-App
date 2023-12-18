using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gaze : MonoBehaviour
{
    List<InfoPanelBehaviour> infos = new List<InfoPanelBehaviour>();
    void Start()
    {
        infos = FindObjectsOfType<InfoPanelBehaviour>().ToList();
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag(("hasInfo")))
            {
                OpenInfo(go.GetComponent<InfoPanelBehaviour>());
                print("HERE");
            }
            else
            {
                CloseAll();
            }

        }
    }

    void OpenInfo(InfoPanelBehaviour desiredInfo)
    {
        foreach(InfoPanelBehaviour info in infos)
        {
            if (info != desiredInfo)
            {
                info.CloseInfo();
            }
            else
            {
                info.OpenInfo();
            }
        }
    }

    void CloseAll()
    {
        foreach(InfoPanelBehaviour info in infos)
        {
            info.CloseInfo();
        }
    }
}
