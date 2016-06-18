using UnityEngine;
using System.Collections;

public class PondScript : MonoBehaviour {

    public GameObject scorescreen;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "duck" && ScoreManager.allDucklingsGathered == true) {
            scorescreen.SetActive(true);
        }
    }
    
}
