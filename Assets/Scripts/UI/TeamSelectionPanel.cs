using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class TeamSelectionPanel : PanelBase
{
    [Header("Buttons")] 
    [SerializeField] private Button _teamHunterButton;
    [SerializeField] private Button _teamPropButton;

    protected override void OnOpened()
    {
        _teamHunterButton.onClick.AddListener(OnTeamHunterButtonClick);
        _teamPropButton.onClick.AddListener(OnTeamPropButtonClick);
    }

    private void OnTeamHunterButtonClick()
    {
        Player player = PhotonNetwork.LocalPlayer;
        player.JoinTeam(1);
    }
    
    private void OnTeamPropButtonClick()
    {
        Player player = PhotonNetwork.LocalPlayer;
        player.JoinTeam(2);
    }

    protected override void OnClosed()
    {
        _teamHunterButton.onClick.RemoveListener(OnTeamHunterButtonClick);
        _teamPropButton.onClick.RemoveListener(OnTeamPropButtonClick);
    }
    
    
}
