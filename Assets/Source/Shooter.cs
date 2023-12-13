using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ObjectPool bulletPool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject bullet = bulletPool.TryGetFromPool();


            if (bullet != null)
            {
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
            }
        }
    }
}