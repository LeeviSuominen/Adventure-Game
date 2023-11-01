using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    [SerializeField] int damageAmount = 1;
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            AudioManager.instance.Play("SwordHit");
            FindObjectOfType<GameManager>().HurtSpider(damageAmount);
        }
    }
}
