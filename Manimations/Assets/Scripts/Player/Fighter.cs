using UnityEngine;
using System.Collections;

[System.Serializable]
public class Fighter
{
    public enum State { move, attack, idle, block, dead };

    private State state;

    public Fighter()
    {
        state = State.idle;
    }

    public void Attack(Fighter attackTarget)
    {
        // Attacking logic goes here

        // Something along the lines of calling its attacked method, and passing this to it
        attackTarget.Attacked(this);

        // Also probably want to decide what this guy should do in the event that the attackTarget blocks, or doesn't
    }

    public void Block()
    {
        // Blocking logic goes here
    }

    public void Attacked(Fighter attacker)
    {
        // Attacked logic goes here
    }

    public State GetState()
    {
        return state;
    }

    public void SetState(State state)
    {
        this.state = state;
    }
}
