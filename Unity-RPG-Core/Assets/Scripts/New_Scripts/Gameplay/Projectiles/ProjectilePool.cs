using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : SingletonBehaviour<ProjectilePool>
{
    [System.Serializable] public class Pool { public string tag; public GameObject prefab; public int size; }
    [SerializeField] private List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDict;

    private void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();
        foreach(var p in pools)
        {
            var q = new Queue<GameObject>();
            for(int i=0;i<p.size;i++)
            {
                var obj = Instantiate(p.prefab);
                obj.SetActive(false);
                q.Enqueue(obj);
            }
            poolDict[p.tag] = q;
        }
    }

    public GameObject Spawn(string tag, Vector3 pos, Quaternion rot)
    {
        if(!poolDict.ContainsKey(tag)) return null;
        var q = poolDict[tag];
        var obj = q.Dequeue();
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.SetActive(true);
        q.Enqueue(obj);
        return obj;
    }
}