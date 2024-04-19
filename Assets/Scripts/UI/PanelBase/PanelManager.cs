using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] public PanelBase[] panels;
    public static PanelManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    
    
    public void OpenPanel<T>() where T: PanelBase
    {
        {
            foreach (var panel in panels)
            {
                if (panel is T)
                {
                    panel.Open();
                }
                else
                {
                    panel.Close();
                }
            }
        }
    }

    public void ClosePanel(PanelBase panel)
    {
        panel.Close();
    }

    

}
