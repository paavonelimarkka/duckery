using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PondScript : MonoBehaviour {

    public GameObject scorescreen;
    public Text scoretext;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "duck" && ScoreManager.allDucklingsGathered == true) {
            scoretext.text = ScoreManager.ducklingsAlive.ToString();
            scorescreen.SetActive(true);
        }
    }
    
}
