using UnityEngine;
using System.Collections;

public class AttackTimer
{
    public PlayerController parent;

    const float ATTACKDELAY = 20 / 60;
    const float ATTACKCOOLDOWN = 2;
    float attackTimer = 0;

    public AttackTimer(PlayerController parent)
    {
        Debug.Log("Player has made an AttackTimer");
        this.parent = parent;
    }

    public bool Update()
    {
        if (parent != null)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= ATTACKDELAY)
            {
                if (parent != null)
                {
                    parent.Attack();
                    parent = null;
                }

                if (attackTimer >= ATTACKCOOLDOWN)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

public class PlayerController : MonoBehaviour
{
    public PlayerController otherPlayer;
    public SpawnPoint spawn;
    public Animator selfAnimator;
    public Rigidbody selfRigid;
    
    enum State { start, idle, walk, run, attack, block, bash, charge, dead };

    State state = State.idle;
    State stateLast = State.start;

    bool isAttacked = false;
    AttackTimer attackTimer = null;

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
        if (state != State.dead)
        {
            state = State.idle;
        }

        if (attackTimer != null)
        {
            if(!attackTimer.Update())
            {
                Debug.Log("Should Attack");
                attackTimer = null;
            }
        }

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
            // I need to rotate the movement vector so that +z is toward COM
            Vector3 delta = CameraBehaviour.COM - transform.position;
            float angle = Mathf.Atan2(delta.z, delta.x);
            movement = new Vector3(movement.z, 0, movement.x);
            movement = new Vector3(movement.x * Mathf.Cos(angle) - movement.z * Mathf.Sin(angle), 0, movement.x * Mathf.Sin(angle) + movement.z * Mathf.Cos(angle));

            selfRigid.MovePosition(transform.position + movement * Time.deltaTime);

            if (movement.magnitude > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f);
            }
        }

        if (anim.IsName("Attack") && attackTimer == null)
        {
            attackTimer = new AttackTimer(this);
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

                    spawn.Respawn();
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

    public void Attack()
    {
        Debug.Log("Attack!");

        // Check distance and direction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.SphereCastAll(ray, 2, 1);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Hit player");
                if (hit.collider.gameObject != this.gameObject)
                {
                    Debug.Log("Hit enemy");
                    hit.collider.gameObject.SendMessage("Attacked", this, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    public void Attacked(PlayerController attacker)
    {
        Debug.Log("Attacked!");

        // This is used for specific logic
        // Which is a very generic comment.
        if (state != State.block)
        {
            Debug.Log("Should Die");
            state = State.dead;
        }
    }

    public void Respawn()
    {
        // Any other logic for respawning should go here too
        state = State.idle;
    }
}
