using System.Collections.Generic;
using UnityEngine;

public class EffectsPool : MonoBehaviour
{
    public static EffectsPool SharedInstance;
    public List<ParticleSystem> pooledObjects;
    public ParticleSystem objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<ParticleSystem>();
        ParticleSystem tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, transform);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public ParticleSystem GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
