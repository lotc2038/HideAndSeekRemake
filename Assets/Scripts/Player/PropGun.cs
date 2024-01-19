using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropGun : Gun
{
    int range = 10;
    public override void Shoot()
    {
        var direction = transform.forward;
        var ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, range))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IProp prop))
            {
                Debug.Log("This is prop");
            }

        }
    }
}
