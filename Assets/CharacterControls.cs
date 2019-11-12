using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class CharacterControls : MonoBehaviour
{
    ETCJoystick etcJoystick = null;
    Animator animator = null;

    //public float MoveSpeed = 0.01f;
    //public float RotateSpeed = 1.0f;
    
    enum State
    {
        Move,
        Idle,
        Attack,
    }

    private State state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        etcJoystick = this.gameObject.GetComponent<ETCJoystick>();

        etcJoystick.onMoveStart.AddListener(OnMoveStart);
        etcJoystick.onMoveEnd.AddListener(OnMoveEnd);
    }

    //private void OnEnable()
    //{
    //    etcJoystick.onTouchStart.AddListener(OnMoveStart);
    //    etcJoystick.onTouchUp.AddListener(OnMoveEnd);
    //}

    //private void OnDisable()
    //{
    //    etcJoystick.onTouchStart.RemoveListener(OnMoveStart);
    //    etcJoystick.onTouchUp.RemoveListener(OnMoveEnd);
    //}

    public void OnMoveStart()
    {
        state = State.Move;
    }

    public void OnMoveEnd()
    {
        state = State.Idle;
    }

    void Update()
    {
        if (state == State.Idle)
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Run", false);
        }
        else if (state == State.Move)
        {
            animator.SetBool("Run", true);
        }
        else if (state == State.Attack)
        {
            animator.SetBool("Eat", true);
        }
    }
}
