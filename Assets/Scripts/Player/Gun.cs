using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    [SerializeField]
    public int damagePerShot;
    public int range;
    public int fireRate;
    public int spread;

    public int maxAmmo=10;
    private int currentAmmo = 1;
    public float reloadTime = 1f;



    public virtual void Shoot()
    {
        if (currentAmmo <= 0) {
            Debug.Log("Need reload");
            Reload();
            Debug.Log("Realoded");
        }

        var direction = transform.forward;
        var ray = new Ray(transform.position, direction);
        currentAmmo--;
        if(Physics.Raycast(ray, out RaycastHit hitInfo, range))
        {
           var hitCollider = hitInfo.collider;

            if(hitCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damagePerShot);
            }

        }
    }

    public void Reload()
    {
        //Сделать через событие или корутину?
        Debug.Log("Reloading");
        currentAmmo = maxAmmo;
        
    }


}
