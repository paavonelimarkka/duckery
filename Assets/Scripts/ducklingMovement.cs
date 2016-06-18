using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ducklingMovement : MonoBehaviour {

    public Transform goal;
    public float range = 10.0f;
	public bool seuraa = false;
	public GameObject duck;
	public GameObject duck_collection;
	public GameObject duckling;
	public GameObject kuolonhuuto;
	public Transform kuolonmesta;
	public Text scoreText;
	public int score;
	public GameObject Score;
	public GameObject gameCtrl;

    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    void Start() {
		score = 0;
		scoreText.text = "SCORE : " + score;
    }

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "duck" && seuraa == false) {
			Debug.Log ("Ankanpoikanen osui ankkaan");
			seuraa = true;
			duck_collection.GetComponent<AudioSource> ().Play ();
            ScoreManager.ducklingsGathered++;
			//  gameCtrl.GetComponent<GameController> ().CountDucks (1);
	        //	Score ScoreCount.AddScore (2);
		    //	GetComponent<CapsuleCollider> ().enabled = false;
		}

		if (other.gameObject.tag == "sewer") {
	        //	gameObject.GetComponentInChildren<MeshRenderer> ().enabled = false;
	        //	gameObject.GetComponent<ParticleSystem> ().Play ();
			gameObject.SetActive(false);
			kuolonhuuto.GetComponent<AudioSource> ().Play ();
            ScoreManager.ducklingsAlive--;
			//  gameCtrl.GetComponent<GameController> ().CountDucks (1);
            //	AddScore (-1);
		    //	kuolonmesta new ParticleSystem ().Play;
		}

	} 

    void Update()
    {
        NavMeshAgent ankka = GetComponent<NavMeshAgent>();
        Vector3 point;
		if (RandomPoint (transform.position, range, out point) && seuraa == false) {
			Debug.DrawRay (point, Vector3.up, Color.blue, 1.0f);
			ankka.destination = point;
		}
			if (seuraa == true) {
			ankka.destination = duck.gameObject.transform.position - new Vector3(0f,0f,-1f);
		}
     }
    
}
