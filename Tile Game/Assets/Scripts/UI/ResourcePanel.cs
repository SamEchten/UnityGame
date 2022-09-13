using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI goldText;

    public GameObject inventoryOb;
    private Inventory inventory;

    void Start()
    {
        inventory = inventoryOb.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = "Wood: " + inventory.wood;
        stoneText.text = "Stone: " + inventory.stone;
        goldText.text = "Gold: " + inventory.gold;
    }
}
