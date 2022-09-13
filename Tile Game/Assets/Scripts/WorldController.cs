using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    //UI fields
    public GameObject resourcePanel;

    Inventory inventory;
    Camera cam;
    GameObject[] tiles;
     
    float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        cam = Camera.main;
        tiles = GameObject.FindGameObjectsWithTag("tile");

        spawnInterval = 30;
        InvokeRepeating("spawnMineables", 0, spawnInterval);
    }

    void Update()
    {
        onClick();
    }

    void spawnMineables()
    {
        GameObject tile = pickRandomTile();
        tile.GetComponent<Tile>().spawnMineable();
    }

    GameObject pickRandomTile()
    {
        int rand = Random.Range(0, tiles.Length);
        return tiles[rand];
    }

    // Update is called once per frame
    

    private void onClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject hit = rayCastHit();
            if(hit)
            {
                Mineable mineable = hit.GetComponent<Mineable>();
                if (mineable != null)
                {
                    mineableHandler(mineable);
                }
            }
        }
    }

    private void mineableHandler(Mineable mineable)
    {
        //Harvest resourse from mineable
        if (!mineable.harvested)
        {
            Resource resource = mineable.harvest();
            inventory.addResource(resource);
        }

        inventory.test();
    }


    private GameObject rayCastHit()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        } else
        {
            return null;
        }
    }
}
