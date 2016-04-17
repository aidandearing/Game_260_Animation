using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator selfAnimator;
    public Rigidbody selfRigid;
    
    enum State { start, idle, walk, run, attack, block, bash, charge, dead };

    State state = State.idle;
    State stateLast = State.start;

    bool isAttacked = false;

    // Use this for initialization
    void Start()
    {
        selfAnimator.SetBool("isWalking", false);
        selfAnimator.SetBool("isAttacking", false);
        selfAnimator.SetBool("isBlocking", false);
        selfAnimator.SetBool("isGrabbing", false);
        selfAnimator.SetBool("isTaunting", false);
        selfAnimator.SetBool("isRunning", false);
        selfAnimator.SetBool("isAttacked", false);
        selfAnimator.SetBool("isStunned", false);
        selfAnimator.SetBool("isDead", false);
        selfAnimator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        state = State.idle;

        UpdateInput();
        UpdateState();

        isAttacked = false;
    }

    void UpdateInput()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement += new Vector3(1, 0, 0);
        }

        if (movement.magnitude > 0)
        {
            movement.Normalize();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement *= 5.0f;
                state = State.run;
            }
            else
            {
                movement *= 1.5f;
                state = State.walk;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
        {
            state = State.attack;
        }

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetButton("Fire2"))
        {
            if (state == State.attack)
            {
                state = State.bash;
            }
            else if (state == State.run)
            {
                state = State.charge;
            }
            else
            {
                state = State.block;
            }
        }

        AnimatorStateInfo anim = selfAnimator.GetCurrentAnimatorStateInfo(0);

        if (anim.IsName("Walk") || anim.IsName("Run") || anim.IsName("Shield Charge"))
        {
            if (state == State.run && (anim.IsName("Run") || anim.IsName("Shield Charge")))
            {
                movement *= 3.0f;
            }
            else if (state == State.walk && anim.IsName("Walk"))
            {
                movement *= 1.5f;
            }

            selfRigid.MovePosition(transform.position + movement * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f);
        }
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
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", true);
                }
                break;
            case State.walk:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", true);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
            case State.run:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", true);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
            case State.attack:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", true);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
            case State.block:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", true);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
            case State.dead:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", false);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", true);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
            case State.bash:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", true);
                    selfAnimator.SetBool("isBlocking", true);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", false);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
            case State.charge:
                // This is newly changed
                if (state != stateLast)
                {
                    selfAnimator.SetBool("isWalking", false);
                    selfAnimator.SetBool("isAttacking", false);
                    selfAnimator.SetBool("isBlocking", true);
                    selfAnimator.SetBool("isGrabbing", false);
                    selfAnimator.SetBool("isTaunting", false);
                    selfAnimator.SetBool("isRunning", true);
                    selfAnimator.SetBool("isAttacked", false);
                    selfAnimator.SetBool("isStunned", false);
                    selfAnimator.SetBool("isDead", false);
                    selfAnimator.SetBool("isIdle", false);
                }
                break;
        }

        stateLast = state;
    }

    public void Attacked(PlayerController attacker)
    {

    }

    void Attack()
    {

    }
}
