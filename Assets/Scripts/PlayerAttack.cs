using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    Animator anim_;
    private void Awake() {
        anim_ = GetComponent<Animator>();
    }

    public void OnAttack1(InputValue value){
        if (value.isPressed){
            MeleeAttack();
        }
    }

    public void OnAttack2(InputValue value){
        if(value.isPressed){
            RangedAttack();
        }
    }

    public void RangedAttack(){
        anim_.SetTrigger("Attacking2");
    }

    public void MeleeAttack(){
        anim_.SetTrigger("Attacking1");
    }
    
    
}
