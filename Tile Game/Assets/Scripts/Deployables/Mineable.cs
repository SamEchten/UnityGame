using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mineable : MonoBehaviour
{
    void Start()
    {
        
    }

    abstract public Resource harvest();

}

