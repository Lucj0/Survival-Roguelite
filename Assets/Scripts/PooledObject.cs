using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;

    public void SetPool(ObjectPool owningPool)
    {
        pool = owningPool;
    }

    public void ReturnToPool()
    {
        pool.Return(gameObject);
    }
}
