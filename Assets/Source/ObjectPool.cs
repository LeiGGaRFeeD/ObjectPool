using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;     
    [SerializeField] private int startPoolSize = 10;     
    [SerializeField] private int maxPoolSize = 20;       

    private List<GameObject> bulletPool;    

 
    private static ObjectPool instance;   

    private void Awake()
    {
        bulletPool = new List<GameObject>();


        for (int i = 0; i < startPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
            }
            return instance;
        }
    }
    public GameObject TryGetFromPool()
    {

        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }

        if (bulletPool.Count < maxPoolSize)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
            return bullet;
        }


        return null;
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
