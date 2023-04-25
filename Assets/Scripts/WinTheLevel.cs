using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinTheLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goodJob;
    // Start is called before the first frame update
    private void Start() {
        goodJob.gameObject.SetActive(false);
    }
        private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && enabled) {
           other.gameObject.GetComponent<InputMover>().enabled = false;
           goodJob.gameObject.SetActive(true);
        }
    }
}
