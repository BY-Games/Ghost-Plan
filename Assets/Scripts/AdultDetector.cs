using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float direction;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Adult") {
            Debug.Log("changing direction");
            other.gameObject.GetComponent<Mover>().SetVelocity(-1);
        }
    }
}
