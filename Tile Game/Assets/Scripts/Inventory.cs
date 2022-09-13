using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int wood;
    public int stone;
    public int gold;

    public List<Resource> resources;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addResource(Resource resource)
    {
        resources.Add(resource);
    }

    public string test()
    {
        Debug.Log("test");
        string json = JsonUtility.ToJson(resources);
        Debug.Log(json);
        return null;
    }
}
