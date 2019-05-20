using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenu : MonoBehaviour
{
    [SerializeField]private GameObject HomePanel;
    [SerializeField] private GameObject EmailPanel;
    [SerializeField]private GameObject EmailFieldsPanel;
    [SerializeField] private GameObject EMailListPanel;
    [SerializeField]private GameObject viewModelPanel;
    [SerializeField]private GameObject world;
    [SerializeField]private GameObject PlaneRenderTexture;

    public void GOMailPanel()
    {
        HomePanel.SetActive(false);
        EMailListPanel.SetActive(false);

        EmailFieldsPanel.SetActive(true);
        EmailPanel.SetActive(true);
    }

    public void GoHomePanel()
    {
        EmailPanel.SetActive(false);
        EmailFieldsPanel.SetActive(false);
        viewModelPanel.SetActive(false);
        world.SetActive(false);
        PlaneRenderTexture.SetActive(false);
        EMailListPanel.SetActive(false);

        HomePanel.SetActive(true);
    }

    public void GoViewModelPanel()
    {
        HomePanel.SetActive(false);

        PlaneRenderTexture.SetActive(true);
        world.SetActive(true);
        viewModelPanel.SetActive(true);
    }

    public void ShowMailListPanel()
    {
        EmailFieldsPanel.SetActive(false);
        EMailListPanel.SetActive(true);
    }

}
