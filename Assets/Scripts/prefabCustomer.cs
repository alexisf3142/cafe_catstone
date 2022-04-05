using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class prefabCustomer : MonoBehaviour
{
    
    private bool orderStatus;
    private int placeInLine; // add this in later
    private List<string> orderList = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        this.orderStatus = false;
        this.placeInLine = 0;
        generator gen = new generator();
        this.orderList = gen.genrateOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool getOrderStatus (){
        return this.orderStatus;
    }
}
