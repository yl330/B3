using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIMovement : MonoBehaviour
{
    NavMeshAgent navAgent;
    Animator animator;

    [SerializeField] bool isJump;
    [SerializeField] OffMeshLinkData curOffMeshLinkData;

    [SerializeField] Vector3 jumpStart;
    [SerializeField] Vector3 jumpEnd;

    [SerializeField] float curJumpTime;
    [SerializeField] float maxJumpTime = 2.0f;

    [SerializeField] AgentLinkMover agentLinkMover;


    [SerializeField] Slider slider;
    [SerializeField] Text text;

    private void Awake()
    {
        navAgent = this.transform.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        agentLinkMover = this.transform.GetComponent<AgentLinkMover>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        #region UI

        text.text = slider.value.ToString();

        #endregion

        navAgent.speed = slider.value;

        if(agentLinkMover.isJump)
        {
            animator.SetFloat("Speed", slider.value / slider.maxValue);
            return;
        }

        if (navAgent.velocity == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", navAgent.velocity.magnitude / slider.maxValue);
        }

        if(Input.GetMouseButton(0))
        {
            print("Move");
            MouseClickCheck();
        }
    }

    void MouseClickCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        Physics.Raycast(ray, out hitInfo, LayerMask.GetMask("Ground"));

        if (hitInfo.collider == null)
            return;

        if (hitInfo.collider.tag != "Ground")
            return;

        //NavMeshHit navHitInfo;
        navAgent.destination = hitInfo.point;
    }

    public void JumpEnd()
    {
        print("JumpEnd");
        agentLinkMover.isJump = false;
        agentLinkMover.canJump = false;
        animator.speed = 1.0f;
    }


}
