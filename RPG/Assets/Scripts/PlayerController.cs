using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public float Velocity;
    public Rigidbody rb;
    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GetInput();
        move();
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SetVelocity(-1);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            SetVelocity(0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            SetVelocity(1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            SetVelocity(0);
        }
    }

    void move()
    {
        if (Velocity == 0)
        {
            anim.SetInteger("Contrall", 0);
            return;
        }
        else
        {
            anim.SetInteger("Contrall", 1);
        }

        rb.MovePosition ( transform.position + (Vector3.right * Velocity * Speed * Time.deltaTime));
    }

    void SetVelocity(float dir)
    {
        if(dir < 0) transform.LookAt(transform.position+ Vector3.left);
       
        else if(dir > 0) transform.LookAt(transform.position+ Vector3.right);
       
        Velocity = dir;
    }
}
