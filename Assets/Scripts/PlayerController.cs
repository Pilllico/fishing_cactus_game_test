using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    public float rotation_speed = 30f;
    public AudioClip engine;
    public AudioClip fire;
    public GameObject shell_body;

    private AudioSource audio_source;
    private Rigidbody rigid_body;
    private float movement_input;
    private float turn_input;
    private float shell_offset = 10;


    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        movement_input = Input.GetAxis("Vertical");
        turn_input = Input.GetAxis("Horizontal");

        if (!audio_source.isPlaying)
        {
            EngineAudio();
        }
    }


    private void EngineAudio()
    {
        audio_source.clip = engine;
        audio_source.Play();
    }


    private void FixedUpdate()
    {
        Move();
        Rotate();

        if (Input.GetKeyDown("space"))
        {
            Fire();
        }
        CheckPosition();
    }

    private void Move()
    {
        Vector3 movement = -transform.right * movement_input * speed * Time.deltaTime;
        rigid_body.MovePosition(rigid_body.position + movement);
    }

    private void Rotate()
    {
        float turn = turn_input * rotation_speed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        rigid_body.MoveRotation(rigid_body.rotation * rotation);
    }

    private void Fire()
    {
        audio_source.clip = fire;
        audio_source.Play();

        Instantiate(shell_body, rigid_body.position - transform.right * shell_offset + new Vector3(0, 2, 0), rigid_body.rotation);
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
