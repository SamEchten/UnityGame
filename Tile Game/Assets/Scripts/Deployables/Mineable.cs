using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mineable : MonoBehaviour
{
    public bool harvested;
    void Start()
    {
        
    }

    abstract public Resource harvest();

}

