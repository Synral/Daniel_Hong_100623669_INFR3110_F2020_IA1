using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public Boundary boundary;

    //TODO: create a reference to the BulletPoolManager
    public BulletPoolManager _bulletPool;

    void Start()
    {
        boundary.Top = 2.45f;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, bulletSpeed * Time.deltaTime, 0.0f);
    }

    //Resets the bullet if it goes off screen
    private void CheckBounds()
    {
        if (transform.position.y >= boundary.Top)
        {
            _bulletPool.ResetBullet(this.gameObject);
        }
    }
}
