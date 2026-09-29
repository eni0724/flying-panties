using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefabWall;
    public int maxObject = 10;
    List<GameObject> pool;
    public Transform parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i <= maxObject; i++)
        {
            GameObject obj = Instantiate(prefabWall, parent);
            obj.SetActive(false);

            pool.Add(obj);
        }


    }

    public GameObject Get()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;

            } 

        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
