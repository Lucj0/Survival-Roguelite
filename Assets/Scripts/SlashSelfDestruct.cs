using UnityEngine;

public class SlashSelfDestruct : MonoBehaviour
{
    private PooledObject pooledObject;

    void Awake()
    {
        pooledObject = GetComponent<PooledObject>();
    }

    public void SelfDestruct()
    {
        pooledObject.ReturnToPool();
    }
}
