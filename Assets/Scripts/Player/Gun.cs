using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField]
    public int damagePerShot;
    public int range;
    public int fireRate;
    public bool useSpread;
    public int rayCount = 1;
    public float spreadFactor = 1f;

    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime;
    private bool isReadyToShoot = true;


    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReadyToShoot = true;
    }

    public virtual void Shoot()
    {

        if (!isReadyToShoot)
            return;

        if (currentAmmo <= 0) {
           isReadyToShoot = false;
           Debug.Log("Need reload");
           StartCoroutine(Reload());
           return;
        }

        for (int i = 0; i < rayCount; i++)
        {
            PerformShot();
        }

    }

    public void PerformShot()
    {
        var direction = useSpread? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, direction);
        currentAmmo--;
        if (Physics.Raycast(ray, out RaycastHit hitInfo, range))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damagePerShot);
            }

        }
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(5f);
        currentAmmo = maxAmmo;
        isReadyToShoot = true;
        Debug.Log($"Realoded: {currentAmmo}");
    }


    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-spreadFactor, spreadFactor),
            y = Random.Range(-spreadFactor, spreadFactor),
            z = Random.Range(-spreadFactor, spreadFactor),
        };
    }

}
