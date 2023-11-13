using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : IShooting
{
    private const int damagePerShot = 10;
    private const int range = 100;

    private Camera cameraHolder;

    public Gun(Camera cameraHolder)
    {
        this.cameraHolder = cameraHolder;
    }

    public void Shoot()
    {
        Ray ray = cameraHolder.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, range))
        {
            HandleShot(hitInfo.transform);
        }
    }

    private void HandleShot(Transform hitTransform)
    {
        IDamageable targetDamageable = hitTransform.GetComponent<IDamageable>();

      if (targetDamageable != null)
      {
            targetDamageable.TakeDamage(damagePerShot);
      }
    }
}
