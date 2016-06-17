using UnityEngine;
using System.Collections;

public class ducklingMovement : MonoBehaviour {

    public Transform goal;
    public float range = 10.0f;
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 10; i++)
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

    void Update()
    {
        NavMeshAgent ankka = GetComponent<NavMeshAgent>();
        // 
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            ankka.destination = point;
        }
    }
}
