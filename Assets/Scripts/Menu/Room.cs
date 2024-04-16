using UnityEngine;
using UnityEngine.UI;

public class Room : PanelBase
{
    [Header("Buttons")]
    [SerializeField] private Button _startButton;

    protected override void OnOpened()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        PanelManager.Instance.OpenPanel<TeamSelectionPanel>();
        
    }

   
    
    protected override void OnClosed()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }
    
}
