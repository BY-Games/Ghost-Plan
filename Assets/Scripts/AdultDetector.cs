using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float direction;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("changing direction");
        if(other.gameObject.tag == "Bound") {
                    Debug.Log("changing direction");

            gameObject.GetComponent<Mover>().SetVelocity(-1);
        }
    }
}
