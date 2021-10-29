using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    [SerializeField] float dValues;
    public Rigidbody rb;
    public Vector3 jump;


    private void Awake()
    {
        anim = this.transform.GetComponent<Animator>();
        rb = this.transform.GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
        dValues = 0.5f;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        float speed = Input.GetAxis("Vertical");
        float dir = Input.GetAxis("Horizontal");

        //if (speed != 0.0f && dValues <= 1.0f)
        //    dValues += 0.005f;

        //if (dValues > 0.0f && speed == 0.0f)
        //    dValues -= 0.01f;

        anim.SetFloat("Speed", speed * dValues);
        anim.SetFloat("Dir", dir * dValues);

        if (Input.GetKeyDown(KeyCode.E))
            dValues = 1.0f;

        if (Input.GetKeyUp(KeyCode.E))
            dValues = 0.5f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rb.AddForce(jump, ForceMode.Impulse);
           
        }
            

    }
}
