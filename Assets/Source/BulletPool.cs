using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }

    [SerializeField]private GameObject bulletPrefab;
    [SerializeField] private int startPoolSize;
    [SerializeField] private int maxPoolSize;

    private List<GameObject> bulletPool;

    private void Awake()
    {
        Instance = this;
    }
     
    private void Start()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < startPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetFromPool()
    {

        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        if (bulletPool.Count < maxPoolSize)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            bulletPool.Add(bullet);
            return bullet;
        }

        return null;
    }

    public void ReturnToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}