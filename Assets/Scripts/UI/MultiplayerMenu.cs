using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerMenu : PanelBase
{
    [Header("Buttons")] 
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _backButton;

    protected override void OnOpened()
    {
        _createButton.onClick.AddListener(OnCreateButtonClick);
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnCreateButtonClick()
    {
        PanelManager.Instance.OpenPanel<Room>();
    }
    private void OnBackButtonClick()
    {
        PanelManager.Instance.OpenPanel<MainMenu>();
    }

    protected override void OnClosed()
    {
        _createButton.onClick.RemoveListener(OnCreateButtonClick);
        _backButton.onClick.RemoveListener(OnBackButtonClick);
    }
    
}
