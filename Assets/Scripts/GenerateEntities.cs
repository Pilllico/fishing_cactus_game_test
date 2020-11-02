using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEntities : MonoBehaviour
{
    public Terrain terrain;
    public GameObject player;
    public GameObject foe;

    public int nb_foes = 5;

    // Start is called before the first frame update
    void Start()
    {
        int width = terrain.terrainData.heightmapWidth / 3;
        float x_r = Random.Range(-width, width);
        float z_r = Random.Range(-width, width);
        player.transform.position = new Vector3(x_r, 30, z_r);
        Instantiate(player);

        for (int i = 0; i < nb_foes; ++i)
        {
            x_r = Random.Range(-width, width);
            z_r = Random.Range(-width, width);
            foe.transform.position = new Vector3(x_r, 30, z_r);
            Instantiate(foe);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
