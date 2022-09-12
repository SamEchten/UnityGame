using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject placeholder;
    private LayerMask tag;
    // Start is called before the first frame update
    void Start()
    {
        placeholder = GameObject.Find("MineablePlaceholder");
        tag = LayerMask.GetMask("Tile");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnMineable();
        }
    }

    public void spawnMineable()
    {
        int attempts = 0;
        int maxAmountOfAttemps = 50;
        float offset = 1f;

        GameObject spawnedMineable;

        bool found = false;
        while(!found)
        {
            if(attempts < maxAmountOfAttemps)
            {
                GameObject mineable = MineableFactory.getRandomMineable();
                Vector3 scale = mineable.GetComponent<Renderer>().bounds.size;
                scale.y = 2f;

                float xPos = randomNumb();
                float zPos = randomNumb();
                float xPosCol = xPos + gameObject.transform.position.x;
                float zPosCol = zPos + gameObject.transform.position.z;
                Vector3 location = new Vector3(xPosCol, offset, zPosCol);

                Collider[] colliders = Physics.OverlapSphere(location, 0.5f);

                bool collided = false;
                foreach(Collider col in colliders)
                {
                    if(col.gameObject.tag != "tile")
                    {
                        collided = true;
                    }
                }

                if(!collided)
                {
                    location.y -= offset;
                    spawnedMineable = Instantiate(mineable, location, Quaternion.identity);
                    Vector3 curPos = mineable.transform.localPosition;
                    curPos.x = xPos;
                    curPos.z = zPos;
                    mineable.transform.localPosition = curPos;
                    found = true;
                }
                attempts++;
            }
            {
                found = true;
            }
        }
    }

    GameObject placeMineable(GameObject mineable, float xPos, float zPos)
    {
        Vector3 pos = new Vector3(xPos, 0f, zPos);
        GameObject ob = Instantiate(mineable, pos, Quaternion.identity, transform);

        Vector3 curPos = ob.transform.localPosition;
        curPos.x = xPos;
        curPos.z = zPos;
        ob.transform.localPosition = curPos;

        Rigidbody rb = ob.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.detectCollisions = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        return ob;
    }

    float randomNumb()
    {
        return Random.Range(-1f, 1f);
    }
}
