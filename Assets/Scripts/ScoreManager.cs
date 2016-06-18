using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int ducklingsGathered;
    public static int ducklingsAlive;
    public bool allDucklingsGathered = false;

    public GameObject scorescreen = GameObject.FindWithTag("scorescreen");

	// Use this for initialization
	void Start () {
        ducklingsAlive = GameObject.FindGameObjectsWithTag("duckling").Length;
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(ducklingsAlive);
        // Debug.Log(allDucklingsGathered);
        if (ducklingsGathered == ducklingsAlive)
        {
            allDucklingsGathered = true;
            scorescreen.SetActive(true);
        }
	}
}
