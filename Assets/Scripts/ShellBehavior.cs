using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehavior : MonoBehaviour
{
    Vector3 start_pos;
    float speed = 30;
    float g = 9.81f;
    Rigidbody rigid_body;

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = start_pos + 5 * rigid_body.velocity * Time.deltaTime - new Vector3(0, Mathf.Pow(5 * Time.deltaTime, 2) * g / 2, 0);

        rigid_body.velocity = transform.forward * speed;
    }
}
