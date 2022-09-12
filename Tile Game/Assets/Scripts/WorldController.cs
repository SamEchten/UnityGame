using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    Inventory inventory;
    
    //UI fields
    public GameObject woodObj;
    public GameObject stoneObj;
    public GameObject goldObj;

    TextMeshProUGUI woodText;
    //TextMeshPro stoneText;
    //TextMeshPro goldText;

    Camera cam;
    GameObject[] tiles;
     
    float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();

        //UI
        woodText = woodObj.GetComponent<TextMeshProUGUI>();
        //stoneText = stoneObj.GetComponent<TextMeshPro>();
        //goldText = goldObj.GetComponent<TextMeshPro>();

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
        mineable.harvest();
        if(mineable is Tree)
        {
            inventory.wood++;
        } else if(mineable is Rock)
        {
            inventory.stone++;
        }

        updateResourceUI();
    }

    private void updateResourceUI()
    {
        woodText.text = "Wood: " + inventory.wood.ToString();
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
