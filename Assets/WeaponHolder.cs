using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    // Start is called before the first frame update

    public int selectedWeapon;
    
    void Start()
    {
        selectedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") <0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SwitchGun();
        }
        
    }
    
    private void SwitchGun()
    {
        int i = 0;
        foreach(Transform gun in transform)
        {
            if(i == selectedWeapon)
                gun.gameObject.SetActive(true);
            else gun.gameObject.SetActive(false);
            i++;
        }
    }
    
}
