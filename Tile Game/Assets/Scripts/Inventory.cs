using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public int space;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        space = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(Item item)
    {
        if(items.Count < space)
        {
            items.Add(item);
        }
    }

    public Item get(int index)
    {
        if(index > items.Count)
        {
            throw new System.Exception("Index is bigger than inventory space");
        }

        return items[index];
    }
}
