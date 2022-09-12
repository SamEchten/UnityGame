using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Mineable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public Resource harvest()
    {
        Debug.Log("Harvesting Rock");
        return null;
    }
}
