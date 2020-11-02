using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeController : MonoBehaviour
{
    public float speed = 20f;
    public float rotation_speed = 0f;
    public GameObject shell;

    private Rigidbody rigid_body;
    private float shell_offset = 10;


    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody>();
        StartCoroutine(RandomRotation());
    }

    IEnumerator RandomRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            rotation_speed = Random.Range(-50, 50);
        }
    }


    private void FixedUpdate()
    {
        Move();
        Rotate();
        /*
        if (Input.GetKeyDown("space"))
        {
            Fire();
        }
        */
        CheckPosition();
    }

    private void Move()
    {
        Vector3 movement = -transform.right * speed * Time.deltaTime;
        rigid_body.MovePosition(rigid_body.position + movement);
    }

    private void Rotate()
    {
        float turn = rotation_speed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        rigid_body.MoveRotation(rigid_body.rotation * rotation);
    }

    private void Fire()
    {
        shell.transform.position = rigid_body.position - transform.right * shell_offset + new Vector3(0, 2, 0);
        shell.transform.rotation = rigid_body.rotation;
        Instantiate(shell);
    }

    private void CheckPosition()
    {
        if (transform.position.y < 0)
        {
            GameObject world_terrain = GameObject.FindGameObjectsWithTag("Terrain")[0];
            Terrain terrain = world_terrain.GetComponent<Terrain>();
            int width = terrain.terrainData.heightmapWidth / 3;
            float x_r = Random.Range(-width, width);
            float z_r = Random.Range(-width, width);
            transform.position = new Vector3(x_r, 30, z_r);
        }
    }
}
