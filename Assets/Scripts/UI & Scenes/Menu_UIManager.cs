using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject selectionPanel;

    private void Update()
    {
        if (selectionPanel.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                return;
            }
        }
    }
}
