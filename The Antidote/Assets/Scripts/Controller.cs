using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    public Transform firepoint;
    public GameObject bullet;

    // Use this for initialization
    void Start ()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Ground", grounded);

        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }


        if (Input.GetMouseButton(0) == true && Input.GetMouseButton(1) == true)
        {
            anim.SetBool("Shoot", true);
            Shoot();
        }
        if (Input.GetMouseButton(0) == false)
        {
            anim.SetBool("Shoot", false);
        }

        if (Input.GetMouseButton(1) == true)
        {
            anim.SetBool("Aim", true);
        }
        if (Input.GetMouseButton(1) == false)
        {
            anim.SetBool("Aim", false);
        }
 
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
        }

        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }
    }
    public void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }

}
