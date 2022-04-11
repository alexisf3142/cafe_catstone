using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeMachineScript : MonoBehaviour
{
    public GameObject MainManager;
    public GameObject Indicator;

    private bool coffeeReady = false;
    
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
        if (coffeeReady)
        {
            Indicator.GetComponent<SpriteRenderer>().color = Color.white;
            coffeeReady = false;
        }
        else
        {
            makeCoffee();
        }
    }

    IEnumerator  Wait()
    {
        yield return new WaitForSeconds(5);
        Indicator.GetComponent<SpriteRenderer>().color = Color.green;
        coffeeReady = true;
    }
    private void makeCoffee()
    {
        Indicator.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine (Wait());
    }

    
}
