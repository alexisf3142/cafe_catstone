using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject objectSpawn;
    public GameObject objectClone;
    
    // Start is called before the first frame update
    void Start()
    {
        objectClone = Instantiate(objectSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
