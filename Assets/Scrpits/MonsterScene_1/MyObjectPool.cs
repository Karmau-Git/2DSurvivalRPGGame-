using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();
    // ����ؽڵ㣬�����洢���־�������
    private GameObject pool = null;
    private static MyObjectPool instance;
    public static MyObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MyObjectPool();
            }
            return instance;
        }
    }

    public GameObject Get(GameObject prefab)
    {
        GameObject obj;
        if (!objectPool.ContainsKey(prefab.name) || objectPool[prefab.name].Count == 0)
        {
            obj = GameObject.Instantiate(prefab);
            Push(obj);
            if (pool == null)
            {
                pool = new GameObject("ObjectPool");
            }
            // ��ÿ�����󶼴������ڵ����أ��������ɡ���ΪFind��Ҫ����������Ϊ�˽�ʡ���ܣ����ָ��·��
            GameObject childPool = GameObject.Find("ObjectPool/" + prefab.name + "Pool");
            if (!childPool)
            {
                childPool = new GameObject(prefab.name + "Pool");
                childPool.transform.SetParent(pool.transform);
            }
            obj.transform.SetParent(childPool.transform);
        }
        obj = objectPool[prefab.name].Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void Push(GameObject prefab)
    {
        string name = prefab.name.Replace("(Clone)", string.Empty);
        if (!objectPool.ContainsKey(name))
        {
            objectPool.Add(name, new Queue<GameObject>());
        }
        objectPool[name].Enqueue(prefab);
        prefab.SetActive(false);
    }
}
