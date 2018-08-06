using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    #region parameter
    public float initSpeed;
    [SerializeField]
    private float speed;
    public float initGravity;
    [SerializeField]
    private float gravity;

    private float InputH;
    private float InputV;
    private bool jump;
    private float mousePosition;

    [SerializeField]
    private float jumpStartTimeCount = 0f;
    [SerializeField]
    private float jumpEndTimeCount = 0f;

    private float verticalVelocity;
    private CharacterController controller;
    private Vector3 moveVector;
    private Animator anim;

    public int animationFlag;
    private float animationDuration = 2f;
    private float preAnimationDuration = 3.2f + 0.3f; //faster than player duration 2s
    private float StartTime;
    public bool startScore = false;

    public bool isDead = false;
    #endregion

    // Use this for initialization
    void Start()
    {
        speed = initSpeed;
        gravity = initGravity;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        if (animationFlag == 1) animationDuration = 4f;
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (animationFlag == 1)
        {
            if (Time.time - StartTime < preAnimationDuration)
            {
                return;
            }

            if (Time.time - StartTime< animationDuration + preAnimationDuration)
            {
                controller.Move(Vector3.forward * speed * Time.deltaTime);
                jumpEndTimeCount++;
                return;
            }
        }
        else
        {
            if (Time.time - StartTime < animationDuration)
            {
                controller.Move(Vector3.forward * speed * Time.deltaTime);
                jumpEndTimeCount++;
                return;
            }
        }

        startScore = true;

        // set Vector3 to (0,0,0)
        // moveVector = new Vector3(0, 0, 0);
        moveVector = Vector3.zero;

        // calculate verticalVelocity
        if (controller.isGrounded)
        {
            // jump
            jumpEndTimeCount++;
            if (jumpEndTimeCount * Time.deltaTime > 0.1f)
            {
                mousePosition = (Input.mousePosition.x - Screen.width / 2) / Screen.width * 2;
                if (Input.GetKey(KeyCode.Space) || (Input.GetMouseButton(0) && (mousePosition > -0.3 && mousePosition < 0.3)))
                    jump = true;
                if (jump == true)
                {
                    jumpStartTimeCount++;
                    if (jumpStartTimeCount * Time.deltaTime > 0.1f)
                    {
                        verticalVelocity = 5f;
                        jumpStartTimeCount = 0f;
                        jumpEndTimeCount = 0f;
                    }
                }
            }
            else
            {
                jump = false;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        InputH = Input.GetAxis("Horizontal");
        if (Input.GetMouseButton(0))
        {
            mousePosition = (Input.mousePosition.x - Screen.width / 2) / Screen.width * 2;
            if (mousePosition < -0.3 || mousePosition > 0.3)
            {
                #region 1. Fix speed movement
                // Are we holding tough on the roght side?
                /*if (Input.mousePosition.x > Screen.width / 2)
                    InputH = 0.7f;
                else
                    InputH = -0.7f;*/
                #endregion

                #region 2. Vary speed movement
                InputH = mousePosition;
                #endregion
            }
        }
        InputV = 1f;

        // animate
        anim.SetFloat("InputH", InputH);
        anim.SetFloat("InputV", InputV);
        anim.SetBool("jump", jump);

        // X
        if (controller.isGrounded) moveVector.x = InputH * initSpeed;
        else if (verticalVelocity > 0) moveVector.x = InputH * initSpeed * 0.7f;
        else moveVector.x = InputH * initSpeed * 0.5f;
        // Y
        moveVector.y = verticalVelocity;
        // Z
        moveVector.z = InputV * speed;

        controller.Move(moveVector * Time.deltaTime);

        //Death condition
        if(transform.position.y < -5)
        {
            Death();
        }
    }

    public void Setspeed(float modifier = 0)
    {
        speed = initSpeed + (modifier - 1) * 2;
        gravity = initGravity + (modifier) * 2;
    }

    /*
    // It is called every time our capsule hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius/2 && hit.gameObject.tag == "Enemy")
        {
            Death();
        }
    }
    */

    private void Death()
    {
        isDead = true;
    }

    public void Jump()
    {
        jump = true;
    }
}
