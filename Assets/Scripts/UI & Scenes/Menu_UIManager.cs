using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_UIManager : MonoBehaviour
{
    [SerializeField] string urlToOpen;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject selectionPanel;
    [SerializeField] Animator _animator;

    private void Update()
    {
        if (selectionPanel.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                _animator.SetBool("isAnimating", false);
                return;
            }
        }
    }

    public void PlayButton()
    {
        _animator.SetBool("isAnimating",true);
    }

    public void OpenBrowserButtonClicked()
    {
        Application.OpenURL(urlToOpen);
    }
}
