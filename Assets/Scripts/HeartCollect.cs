using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        AudioManager.instance.Play("HeartCollect");

        FindObjectOfType<GameManager>().AddHeart();

        Destroy(gameObject);
    }
}
