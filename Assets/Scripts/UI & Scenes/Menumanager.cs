using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager : MonoBehaviour
{
    [Header("UI Panel References")]
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject selectionPanel;

    [SerializeField] bool isFirst = true;

    private void Start()
    {
        if (isFirst)
        {
            Debug.Log("isfirst true");
            mainPanel.SetActive(true);
            selectionPanel.SetActive(false);
            isFirst = false;
        }
        else
        {
            Debug.Log("isfirst false");
            mainPanel.SetActive(false);
            selectionPanel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (isFirst)
        {
            mainPanel.SetActive(true);
            selectionPanel.SetActive(false);
            Debug.Log("Condition is true");
        }
        else
        {
            mainPanel.SetActive(false);
            selectionPanel.SetActive(true);
            Debug.Log("Condition is false");
        }
    }
}
