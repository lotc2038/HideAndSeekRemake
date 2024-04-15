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
<<<<<<< HEAD
        
    }

   
    
=======
    }

>>>>>>> e25b2fa0c486a026b983f6ebacc7fad5e109cfa7
    protected override void OnClosed()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }
    
}
