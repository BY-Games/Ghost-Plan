using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPass : MonoBehaviour
{
    [SerializeField] Collider2D otherSide;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && enabled) {
            other.transform.position = otherSide.transform.position;
        }
    }
}
