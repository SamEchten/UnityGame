using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableFactory : MonoBehaviour
{
    static public GameObject[] mineables;
    static float treeProb = 0.7f;
    static float rockProb = 0.3f;

    void Awake()
    {
        mineables = Resources.LoadAll<GameObject>("Prefabs/Mineables");
    }

    public static GameObject getRandomMineable()
    {
        float rand = Random.Range(0, 1f);
        if(rand < treeProb)
        {
            return mineables[1];
        } else
        {
            return mineables[0];
        }
    }
}
