using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
    public bool isOpen;

    public event Action Opened;
    public event Action Closed;

    public void Open()
    {
        if(isOpen == true)
            return;
        
        gameObject.SetActive(true);
        isOpen = true;
        OnOpened();
        Opened?.Invoke();
    }


    public void Close()
    {
        if(isOpen == false)
            return;
        
        gameObject.SetActive(false);
        isOpen = false;
        OnClosed();
        Closed?.Invoke();
    }


    protected virtual void OnOpened()
    {
        
    }

    protected virtual void OnClosed()
    {
        
    }
    
}
