using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Room : PanelBase
{
    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _backButton;

    protected override void OnOpened()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnStartButtonClick()
    {
        PanelManager.Instance.OpenPanel<TeamSelectionPanel>();
        
    }

    private void OnBackButtonClick()
    {
        NetworkManager.Instance.LeaveRoom();
        PanelManager.Instance.OpenPanel<MultiplayerMenu>();
     
    }

   
    
    protected override void OnClosed()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _backButton.onClick.RemoveListener(OnBackButtonClick);
    }
    
}
