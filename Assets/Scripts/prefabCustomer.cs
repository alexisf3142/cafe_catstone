using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class prefabCustomer : MonoBehaviour
{
    
    private bool orderStatus;
    private int placeInLine; // add this in later
    private Vector3 targetPos;
    public float speed = 1.0f;
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
        Debug.Log("Prefab");
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public bool getOrderStatus (){
        return this.orderStatus;
    }
    
    public void setTargetPos (Vector3 target)
    {
        this.targetPos = target;
    }
}
