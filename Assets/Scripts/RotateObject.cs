using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] int rotateSpeed_;
    [SerializeField] Vector3 rotateAxis_;

    private void Update() {
        transform.Rotate(rotateSpeed_ * Time.deltaTime * rotateAxis_, Space.World);
    }
}
