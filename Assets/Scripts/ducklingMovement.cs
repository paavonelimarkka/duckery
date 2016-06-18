using UnityEngine;
using System.Collections;

public class ducklingMovement : MonoBehaviour {

    public Transform goal;
    public float range = 10.0f;
	public bool seuraa = false;
	public GameObject duck;
	public GameObject duck_collection;
	public GameObject duckling;
	public GameObject kuolonhuuto;
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
    //    for (int i = 0; i < 10; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    void Start()
    {

    }
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "duck" && seuraa == false) {
			Debug.Log ("Ankanpoikanen osui ankkaan");
			seuraa = true;
			duck_collection.GetComponent<AudioSource> ().Play ();
		//	GetComponent<CapsuleCollider> ().enabled = false;
		}
		if (other.gameObject.tag == "sewer") {
			gameObject.SetActive(false);
			kuolonhuuto.GetComponent<AudioSource> ().Play ();
		}
	} 
    void Update()
    {
        NavMeshAgent ankka = GetComponent<NavMeshAgent>();
        // 
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
