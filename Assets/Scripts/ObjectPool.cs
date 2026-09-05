using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 150;
    private Queue<GameObject> objectQueue;

    void Awake()
    {
        objectQueue = new Queue<GameObject>();

        // Creates n = poolSize objects that are inactive which is the Object Pool
        for (int n = 0; n < poolSize; n++)
        {
            GameObject prefabObject = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
            prefabObject.SetActive(false);
            objectQueue.Enqueue(prefabObject);
        }
    }

    public GameObject Get()
    {
        // Checks if there are enemies left in the pool. If not, return null
        if (objectQueue.Count == 0) return null;

        GameObject pooledObject = objectQueue.Dequeue();
        pooledObject.GetComponent<PooledObject>().SetPool(this);
        pooledObject.SetActive(true);
        return pooledObject;
    }

    // This method recieves enemy from death and puts it back into the queue
    public void Return(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
        objectQueue.Enqueue(pooledObject);
    }
}
