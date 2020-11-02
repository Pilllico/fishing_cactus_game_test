using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEntities : MonoBehaviour
{
    public Terrain terrain;
    public GameObject player;
    public GameObject foe;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(-500, -500, 10);
        Instantiate(player);
        Debug.Log("Done");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
