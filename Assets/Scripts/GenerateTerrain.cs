using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public Terrain terrain;
    TerrainData t_data;

    int t_width;
    int t_height;

    float[,] heights;

    // Start is called before the first frame update
    void Start()
    {
        //Get width and height
        t_data = terrain.terrainData;

        int t_width = t_data.heightmapWidth;
        int t_height = t_data.heightmapHeight;

        float base_height = 0.5f;

        int range = 20;
        int distance = 50;

        //Get heightmap
        heights = t_data.GetHeights(0, 0, t_width, t_height);

        //Manipulate
        for (int x = 0; x < t_width; ++x)
        {
            for (int y = 0; y < t_height; ++y)
            {
                heights[x, y] = base_height;
            }
        }

        for (int x = 0; x < t_width; ++x)
        {
            for (int y = 0; y < t_height; ++y)
            {
                if (x % distance == 0 && y % distance == 0 && x > range && x < t_width - range && y > range && y < t_height - range)
                {
                    heights[x, y] += Random.Range(-base_height, base_height);
                    /*
                    for (int a = 0; a < range; a++)
                    {
                        for (int b = 0; b < range; b++)
                        {
                            float dist_from_center = Mathf.Sqrt(Mathf.Pow((x - a), 2) + Mathf.Pow((y - b), 2));
                            float time = Mathf.Max(1.0f - (dist_from_center / range), 0);
                            if (x + a - range / 2 != x && y - b + range / 2 != y)
                            {
                                heights[x + a - range / 2, y - b + range / 2] = base_height + (heights[x, y] - base_height) * time;
                            }
                        }
                    }
                    */
                }
            }
        }
        //To change Heights
        terrain.terrainData.SetHeights(0, 0, heights);
    }
}