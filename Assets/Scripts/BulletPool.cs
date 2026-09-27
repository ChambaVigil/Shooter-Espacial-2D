using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public GameObject bulletPrefab; 
    public int poolSize = 10; 

    private List<GameObject> bullets; 
    void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        bullets = new List<GameObject>();


        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            bullets.Add(obj);
        }
    }


    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (bullet.GetComponent<Bullet>().enUso == false) 
            {
                return bullet; 
            }
        }
        return null;
    }
}