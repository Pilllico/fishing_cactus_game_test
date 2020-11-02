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
        int width = terrain.terrainData.heightmapWidth / 2;
        player.transform.position = new Vector3(Random.Range(-width, width), 30, Random.Range(-width, width));
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
