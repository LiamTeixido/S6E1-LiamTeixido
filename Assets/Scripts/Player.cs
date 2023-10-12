using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void Update()
    {
        MoveCharacter();

        if (Input.GetMouseButtonDown(0)) 
        {
            Fire();
        }
    }

    protected override void MoveCharacter()
    {
        base.MoveCharacter(); 
    }

    protected virtual void Fire()
    {
        if (gunTransform != null && bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = gunTransform.forward * bulletSpeed;
        }
    }

}
