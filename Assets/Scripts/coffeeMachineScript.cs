using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeMachineScript : MonoBehaviour
{
    public GameObject MainManager;
    public GameObject Indicator;
    public GameObject cup;

    private bool coffeeReady = false;
    
    // Start is called before the first frame update
    void Start()
    {
        hideCup();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (coffeeReady)
        {
            Indicator.GetComponent<SpriteRenderer>().color = Color.white;
            MainManager.GetComponent<gameManager>().setCoffeeDone(true);
            hideCup();
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
        showCup();
    }
    
    public void hideCup()
    {
        cup.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }
    public void showCup()
    {
        cup.GetComponent<SpriteRenderer>().sortingOrder = 11;
    }

    
}