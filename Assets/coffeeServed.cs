using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coffeeServed : MonoBehaviour
{
    
    public Text coffeeServedText;
    public GameObject MainManager;
    
    private int numberOfCustomersPerDay = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfCustomersPerDay = MainManager.GetComponent<gameManager>().getCurrNumOfCustomersLeft();
    }

    private void updateCoffeeServed()
    {
        int NumOfCoffeeServed = numberOfCustomersPerDay -  MainManager.GetComponent<gameManager>().getCurrNumOfCustomersLeft();
        coffeeServedText.text = NumOfCoffeeServed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        updateCoffeeServed();
    }
}
