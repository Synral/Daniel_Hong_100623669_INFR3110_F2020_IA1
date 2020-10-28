using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    // public static BulletPoolManager Instance()
    // {
    //     if (_instance == null)
    //     {
    //         _instance = new BulletPoolManager();
    //     }
    //     return _instance;
    // }
    public GameObject bullet;

    //TODO: create a structure to contain a collection of bullets
    public BulletController bulletController;
    public int _maxBullets;
    private Queue<GameObject> _bulletPool = new Queue<GameObject>();
    // private static BulletPoolManager _instance;

    // Start is called before the first frame update
    void Start()
    {
        bulletController._bulletPool = this;
        // TODO: add a series of bullets to the Bullet Pool
        bullet.SetActive(false);
        _BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        if (getEmpty())
        {
            GameObject temp = MonoBehaviour.Instantiate(bullet, new Vector3(0.0f, -10.0f, 0.0f), Quaternion.identity);
            temp.transform.parent = this.transform;
            _bulletPool.Enqueue(temp);
            _maxBullets++;
        }
        GameObject _bullet = _bulletPool.Dequeue();
        _bullet.SetActive(true);
        return _bullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }

    private void _BuildBulletPool()
    {
        for (int i=0;i<_maxBullets;i++)
        {
            GameObject temp = MonoBehaviour.Instantiate(bullet, new Vector3(0.0f, -10.0f, 0.0f), Quaternion.identity);
            temp.transform.parent = this.transform;
            _bulletPool.Enqueue(temp);
        }
    }
    public int getPoolSize()
    {
        return _bulletPool.Count;
    }

    public bool getEmpty()
    {
        return getPoolSize() <= 0;
    }
}
