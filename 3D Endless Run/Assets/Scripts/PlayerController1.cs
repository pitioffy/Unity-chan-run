using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public Animator anim;
    public float speedX;
    public float speedZ;

    private float InputH;
    private float InputV;
    private bool run;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0f);
        }
        if (Input.GetKeyDown("5"))
        {
            anim.Play("HANDUP00_R", -1, 0f);
        }
        if (Input.GetKeyDown("6"))
        {
            anim.Play("REFLESH00", -1, 0f);
        }
        if (Input.GetKeyDown("7"))
        {
            anim.Play("UMATOBI00", -1, 0f);
        }
        if (Input.GetKeyDown("8"))
        {
            anim.Play("LOSE00", -1, 0f);
        }
        if (Input.GetKeyDown("9"))
        {
            anim.Play("WIN00", -1, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("DAMAGED00", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("DAMAGED01", -1, 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift)) run = true;
        else run = false;

        if (Input.GetKey(KeyCode.Space)) anim.SetBool("Jump", true);
        else anim.SetBool("Jump", false);

        InputH = Input.GetAxis("Horizontal");
        InputV = Input.GetAxis("Vertical");

        anim.SetFloat("InputH", InputH);
        anim.SetFloat("InputV", InputV);
        anim.SetBool("run", run);

        float moveX = InputH * Time.deltaTime * speedX;
        float moveZ = InputV * Time.deltaTime * speedZ;

        if (moveZ < 0) moveX = 0;
        else if(run)
        {
            moveX *= 3f;
            moveZ *= 3f;
        }

        rb.velocity = new Vector3(moveX, 0f, moveZ);
    }
}
