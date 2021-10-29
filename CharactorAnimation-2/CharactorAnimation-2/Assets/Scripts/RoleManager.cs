using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoBehaviour
{
    private static RoleManager instance;
    public static RoleManager Instance { get { return instance; } }


    public List<RoleBase> roleList;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        roleList = new List<RoleBase>();
    }

    void Start()
    {
        
    }

    public void Notify(Vector3 targetPos)
    {
        //TODO 发送通知事件
        foreach (var role in roleList)
        {
            role.MoveToTarget(targetPos);
        }
    }

}
