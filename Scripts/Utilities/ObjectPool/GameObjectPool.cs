using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameObjectPool<T> where T : Component
{
    private Queue<T> pool;
    private T objectRef;
    private Transform objectRoot;
    private int initNum = 10;

    public GameObjectPool(T target, int initNum = 10)
    {
        Init(target, initNum);
    }

    public T GetObject()
    {
        T obj;
        obj = pool.Dequeue();

        if (pool.Count <= 2)
            EnlargePoolSize();

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void RecycleObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }

    private void Init(T target, int initNum)
    {
        objectRef = target;
        this.initNum = initNum;
        pool = new Queue<T>();
        objectRoot = new GameObject($"{typeof(T).Name}_ObjectPool").transform;

        for (int i = 0; i < initNum; i++)
        {
            var obj = Object.Instantiate(objectRef, objectRoot);
            obj.gameObject.SetActive(false);

            pool.Enqueue(obj);
        }
    }

    private void EnlargePoolSize()
    {
        for (int i = 0; i < initNum; i++)
        {
            var newObj = Object.Instantiate(objectRef, objectRoot);
            newObj.gameObject.SetActive(false);

            pool.Enqueue(newObj);
        }
    }
}