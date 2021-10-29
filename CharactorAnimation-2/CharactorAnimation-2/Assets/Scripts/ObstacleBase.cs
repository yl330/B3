using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleBase : MonoBehaviour
{
    Rigidbody rb;
    public List<Transform> pathTfList;
    public int curtIndex;
    public Vector3 targetPos;
    public bool isReturn;

    public float againMoveTime;
    public float movingTime;

    private void Awake()
    {
        rb = this.transform.GetComponent<Rigidbody>();
    }

    void Start()
    {
        curtIndex = 0;

        MoveOnPath();
    }

    private void MoveOnPath()
    {
        if (curtIndex == pathTfList.Count - 1)
            isReturn = true;
        else if (curtIndex == 0)
            isReturn = false;

        curtIndex = isReturn ? curtIndex - 1 : curtIndex + 1;

        targetPos = pathTfList[curtIndex].position;
        rb.DOMove(targetPos, movingTime);

        Invoke("MoveOnPath", againMoveTime);
    }
}
