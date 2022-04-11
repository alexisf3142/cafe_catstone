using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeMachineScript : MonoBehaviour
{
    public GameObject MainManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        MainManager.GetComponent<gameManager>().setCoffeeDone(true);
    }
}
