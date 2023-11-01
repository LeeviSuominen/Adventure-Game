using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonController : MonoBehaviour
{
   [SerializeField] int damageAmount = 1;

   public float poisonSpeed;

   private void Update() {
    transform.Translate(0, 0, poisonSpeed);
   }

   private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")){
        FindObjectOfType<GameManager>().HurtPlayer(damageAmount);
    }
   }
}
