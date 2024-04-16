using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HunterHUD : PanelBase
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;

    public void AmmoUpdate(int ammo)
    {
        ammoText.text = ammo.ToString();
    }

    public void HealthUpdate(int health)
    {
        
    }

  
    
}
