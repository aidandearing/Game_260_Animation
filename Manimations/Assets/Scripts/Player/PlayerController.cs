using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator selfAnimator;
    public Rigidbody selfRigid;

    // 10
    enum AnimatorParameters { walkingSpeed, isWalking, isAttacking, isBlocking, isGrabbing, isTaunting, isRunning, isAttacked, isStunned, isDead };
    enum State { start, idle, walk, run, attack, block, dead };

    State state = State.idle;
    State stateLast = State.start;

    // Use this for initialization
    void Start()
    {
        selfAnimator.SetFloat("movementSpeed", 0.0f);
        selfAnimator.SetBool("isWalking", false);
        selfAnimator.SetBool("isAttacking", false);
        selfAnimator.SetBool("isBlocking", false);
        selfAnimator.SetBool("isGrabbing", false);
        selfAnimator.SetBool("isTaunting", false);
        selfAnimator.SetBool("isRunning", false);
        selfAnimator.SetBool("isAttacked", false);
        selfAnimator.SetBool("isStunned", false);
        selfAnimator.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateState();
    }

    void UpdateInput()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement += new Vector3(0, 0, 1);
            state = State.walk;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement += new Vector3(-1, 0, 0);
            state = State.walk;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement += new Vector3(0, 0, -1);
            state = State.walk;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement += new Vector3(1, 0, 0);
            state = State.walk;
        }

        movement.Normalize();
        movement *= 1;

        selfRigid.MovePosition(transform.position + movement * Time.deltaTime);
    }

    void UpdateState()
    {
        switch (state)
        {
            case State.start:
                // This is newly changed
                if (state != stateLast)
                {

                }
                break;
            case State.idle:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetFloat("movementSpeed", 0.0f);
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                }
                break;
            case State.walk:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetFloat("movementSpeed", 1.0f);
                    selfAnimator.SetBool("isWalking", true);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                }
                break;
            case State.run:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetFloat((int)AnimatorParameters.walkingSpeed, 1.0f);
                    selfAnimator.SetBool((int)AnimatorParameters.isWalking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isBlocking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isGrabbing, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isTaunting, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isRunning, true);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacked, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isStunned, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isDead, false);
                }
                break;
            case State.attack:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetFloat((int)AnimatorParameters.walkingSpeed, 0.0f);
                    selfAnimator.SetBool((int)AnimatorParameters.isWalking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacking, true);
                    selfAnimator.SetBool((int)AnimatorParameters.isBlocking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isGrabbing, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isTaunting, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isRunning, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacked, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isStunned, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isDead, false);
                }
                break;
            case State.block:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetFloat((int)AnimatorParameters.walkingSpeed, 0.0f);
                    selfAnimator.SetBool((int)AnimatorParameters.isWalking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isBlocking, true);
                    selfAnimator.SetBool((int)AnimatorParameters.isGrabbing, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isTaunting, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isRunning, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacked, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isStunned, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isDead, false);
                }
                break;
            case State.dead:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetFloat((int)AnimatorParameters.walkingSpeed, 0.0f);
                    selfAnimator.SetBool((int)AnimatorParameters.isWalking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isBlocking, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isGrabbing, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isTaunting, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isRunning, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isAttacked, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isStunned, false);
                    selfAnimator.SetBool((int)AnimatorParameters.isDead, true);
                }
                break;
        }

        stateLast = state;
    }
}
