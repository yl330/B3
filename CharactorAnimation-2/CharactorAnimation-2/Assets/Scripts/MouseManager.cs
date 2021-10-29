using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseManager : MonoBehaviour
{
    private static MouseManager instance;
    public static MouseManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    

    void Start()
    {
        
    }


    void Update()
    {
        RayCheck();
    }

    void RayCheck()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);

            if(hitInfo.collider)
            {
                if(hitInfo.collider.CompareTag("Role"))
                {
                    //TODO
                    hitInfo.collider.GetComponent<RoleBase>().Selected();
                }
                else if(hitInfo.collider.CompareTag("Ground"))
                {
                    //TODO
                    RoleManager.Instance.Notify(hitInfo.point);
                }
            }
        }
    }
}
