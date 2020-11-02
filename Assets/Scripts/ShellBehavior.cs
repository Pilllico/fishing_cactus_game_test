using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehavior : MonoBehaviour
{
    Vector3 start_pos;
    Quaternion velocity;
    float speed = 30;
    float g = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = transform.rotation * Quaternion.Euler(speed, speed, speed);
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(
            start_pos.x + 5 * velocity.x * Time.deltaTime,
            start_pos.y + 5 * velocity.y * Time.deltaTime,
            start_pos.z + 5 * velocity.z * Time.deltaTime);
        pos.y -= Mathf.Pow(5 * Time.deltaTime, 2) * g / 2;
        transform.position = pos;
    }
}
