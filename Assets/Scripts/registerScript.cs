using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class registerScript : MonoBehaviour
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
        MainManager.GetComponent<gameManager>().setTringToCheckout(true);
        if (MainManager.GetComponent<gameManager>().isPlayerHoldingCup() && MainManager.GetComponent<gameManager>().numOfCustomer() > 0)
        {
            MainManager.GetComponent<gameManager>().checkOutCustomer();
        }
    }
}
