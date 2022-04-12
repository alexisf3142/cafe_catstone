using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillManager : MonoBehaviour
{
    public GameObject Waypoints;
    private List<Vector3> spillPositions;
    
    private GameObject spillPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        spillPositions = new List<Vector3>();
        spillPositions.Add(Waypoints.transform.GetChild(0).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(1).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(2).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(3).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(4).transform.position);
        StartCoroutine (Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator  Wait()
    {
        yield return new WaitForSeconds(15);
        int num = Random.Range(0, 6);
        Vector3 randSpot = spillPositions[num];
        //Instantiate(spillPrefab, randSpot, transform.position);
        Debug.Log("SPAWNSPILL"); // this runs
    }
}
