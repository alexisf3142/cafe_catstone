using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillManager : MonoBehaviour
{
    public GameObject Waypoints;
    private List<Vector3> spillPositions;
    
    private List<GameObject> spills;
    
    public GameObject spillPrefab;

    public GameObject Profile;

    // Start is called before the first frame update
    void Start()
    {
        spillPositions = new List<Vector3>();
        spills = new List<GameObject>();
        spillPositions.Add(Waypoints.transform.GetChild(0).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(1).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(2).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(3).transform.position);
        spillPositions.Add(Waypoints.transform.GetChild(4).transform.position);
        //StartCoroutine (Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator  Wait()
    {
        yield return new WaitForSeconds(15);
        int num = Random.Range(0, 5);
        Vector3 randSpot = spillPositions[num];
        spills.Add(Instantiate(spillPrefab, randSpot, transform.rotation));
        Debug.Log("SPAWNSPILL"); 
    }
    
    private int lastSpill = 5;
    public void  SpillCoffee()
    {
        if (lastSpill == 5)
        {
            int num = Random.Range(0, 5);
            lastSpill = num;
            Vector3 randSpot = spillPositions[num];
            spills.Add(Instantiate(spillPrefab, randSpot, transform.rotation));
            Profile.GetComponent<ProfileUpdated>().CoffeeSpilledReaction();   
        }
        else
        {
            int num = Random.Range(0, 4);
            if (num == lastSpill)
            {
                num = num + 1;
            }
            lastSpill = num;
            Vector3 randSpot = spillPositions[num];
            spills.Add(Instantiate(spillPrefab, randSpot, transform.rotation));
            Profile.GetComponent<ProfileUpdated>().CoffeeSpilledReaction();  
        }
    }

    public bool tryToClean(Vector3 playerPos)
    {
        if (spills.Count > 0)
        {
            for (int i = 0; i < spills.Count; i++)
            {
                float distance = Vector3.Distance(playerPos, spills[i].transform.position);
                if (distance < 1f)
                {
                    GameObject currSpill = spills[i];
                    spills.Remove(currSpill);
                    Destroy(currSpill);
                    return true;
                }
            }
        }

        return false;
    }

    public int getNumberOfSpills()
    {
        return spills.Count;
    }
}
