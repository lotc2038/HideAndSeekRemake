using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu[] menus;
    public static MenuManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // TODO: ���������� ���� ��������

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].name == menuName)
            {
                OpenMenu(menus[i]);
            }

        }
        
    }

    public void OpenMenu(Menu menu)
    {
        for(int i = 0;i < menus.Length;i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
