using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpead = 20f;
    public float panBorderThickness = 10f;

    float inputx;
    public float inputy;

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.z += panSpead * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpead * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpead * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpead * Time.deltaTime;
        }
        if (Input.GetKey("space"))
        {
            pos.y += panSpead * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            pos.y -= panSpead * Time.deltaTime;
        }
        transform.position = pos;
        inputx = Input.GetAxis("Horizontal");
        inputy = Input.GetAxis("Vertical");
        if (inputx != 0)
        {
            rotate();
        }
        if (inputy != 0)
        {
            move();
        }

    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, inputx * Time.deltaTime * 3, 0f));
    }

    private void move()
    {
        transform.position += transform.forward * inputy * Time.deltaTime * 3;
    }
}
