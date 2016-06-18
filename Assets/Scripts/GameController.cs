using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int ducks;
	// Use this for initialization
	public void CountDucks(int duck) {
		ducks += duck;
		Debug.Log (ducks);
	}
	void Start () {
		ducks = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
