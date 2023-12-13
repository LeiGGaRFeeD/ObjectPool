using UnityEngine;


public class Bullet : MonoBehaviour
{
    private float speed = 5f;


    private void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}