using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class registerScript : MonoBehaviour
{
    public GameObject MainManager;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool tryToInteractWithRegister()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 1.3f)
        {
            MainManager.GetComponent<gameManager>().setTringToCheckout(true);
            if (MainManager.GetComponent<gameManager>().isPlayerHoldingCup() && MainManager.GetComponent<gameManager>().numOfCustomer() > 0)
            {
                MainManager.GetComponent<gameManager>().checkOutCustomer();
            }
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tryToInteractWithRegister();

        }
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
