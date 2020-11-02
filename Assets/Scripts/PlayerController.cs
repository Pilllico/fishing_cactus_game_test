using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    public float rotation_speed = 30f;
    public AudioClip engine;
    public GameObject shell;

    private AudioSource audio_source;
    private Rigidbody rigid_body;
    private float movement_input;
    private float turn_input;
    private float fire_input;
    private Vector3 shell_offset = new Vector3(-8, 2, 0);


    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        movement_input = Input.GetAxis("Vertical");
        turn_input = Input.GetAxis("Horizontal");
        fire_input = Input.GetAxis("Fire1");

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
        shell_offset = rigid_body.rotation * shell_offset;
    }

    private void Fire()
    {
        shell.transform.position = rigid_body.position + shell_offset;
        shell.transform.rotation = rigid_body.rotation;
        Instantiate(shell);
    }
}
