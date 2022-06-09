using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //component neecessary
   [SerializeField] private Rigidbody2D _rig;
   [SerializeField] private Animator _animator;
    //stat
   [SerializeField] private float _moveSpeed = 20f;
    private float mMoveSpeed;
    [SerializeField] private float _DashSpeed = 20f;
    [SerializeField] Warrior war;
    private float mDash;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rig = GetComponent<Rigidbody2D>();
        mMoveSpeed = _moveSpeed;
    }

    public void move(Vector2 moveVec,bool dash)
    {
        
        _rig.velocity = moveVec * _moveSpeed ;
        if (dash)
        {
            //todo
        }
       
    }
    
    //Anim control
    public void AMove(Vector2 moveVec)
    {
        _animator.SetFloat("MoveX", moveVec.x);
        _animator.SetFloat("MoveY", moveVec.y);
        _animator.SetFloat("Speed", moveVec.sqrMagnitude);
    }

  
}
