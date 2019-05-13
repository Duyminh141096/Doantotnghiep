using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] prefabs;

    public int amountObject;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static ObjectPooler Instance;

    public GameController gameController;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GrowPool();
    }
    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            GrowPool();
        }
        GameObject instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
    void GrowPool()
    {
        for (int i = 0; i < amountObject; i++)
        {
            
            GameObject instanceToAdd = Instantiate(prefabs[gameController.ran]);

            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.transform.position = Vector3.zero;
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

}
