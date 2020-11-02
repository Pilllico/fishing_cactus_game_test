using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = player.transform.position;
        Debug.Log(p);
        transform.position.Set(p.x + offset.x, p.y + offset.y, p.z + offset.z);
        transform.LookAt(player.transform);
    }
}
