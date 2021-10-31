
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //旋转参数
    private float xspeed = -0.05f; // X速率
    private float yspeed = 0.1f;   // y速率

    private Vector3 center; // 视角中心点

    enum RotationAxes { MouseXAndY, MouseX, MouseY }
    RotationAxes axes = RotationAxes.MouseXAndY;

    float sensitivityX = 5;
    float sensitivityY = 5;
    float sensitivityC = 12;
    float minimumY = -80;
    float maximumY = 80;
    private float rotationY = 0;
    public float min_distance = 1; //最大小距离
    public float max_distance = 150; // 最大距离

    public float panSpead = 20f;
    public float panBorderThickness = 10f;

    float inputx;
    public float inputy;

    private void Start()
    {
        center = Vector3.zero;
    }

    private void Update()
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

        var c = Camera.main;
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // 视角拉近
        {
            float d = Vector3.Distance(center, transform.position);
            if (d >= min_distance)
            {
                var dir = transform.position - center;
                dir = dir.normalized * (d - 10 * sensitivityC * Time.deltaTime);
                transform.position = dir + center;
                if (d <= min_distance)
                {
                    dir = dir.normalized * (min_distance);
                    transform.position = dir + center;
                }
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) // 视角拉远
        {
            float d = Vector3.Distance(center, transform.position);
            if (Camera.main.fieldOfView <= max_distance)
            {
                var dir = transform.position - center;
                dir = dir.normalized * (d + 10 * sensitivityC * Time.deltaTime);
                transform.position = dir + center;
                if (c.fieldOfView >= max_distance)
                {
                    dir = dir.normalized * (max_distance);
                    transform.position = dir + center;
                }
            }
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
