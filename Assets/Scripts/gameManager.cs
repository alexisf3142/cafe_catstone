using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject customerSpawnPrefab;
    public GameObject Spawner;
    [SerializeField]
    public GameObject counterStart;
    [SerializeField]
    public GameObject ExitWaypoit;
    public bool buttonPressed = false;

    private List<GameObject> theLine;
    private float startOfLineX;
    


    void addCustomer()
    {
        GameObject currCustomer = Instantiate(customerSpawnPrefab, Spawner.transform.position, transform.rotation);
        theLine.Add(currCustomer);
    }
    
    private bool customerOrderCompleted(){
        /*if (theLine[0].prefabCustomer.getOrderStatus())
        {
            return true; 
        }
        else
        {
            return false;
        }*/
        return false;
    }
    
    public int numOfCustomer(){
        return theLine.Count;
    }
    
    private void RemoveFirstCustomerInLine()
    {
        GameObject leavingCustomer = this.theLine[0];
        this.theLine.RemoveAt(0);
        leavingCustomer.transform.position = Vector3.Lerp(leavingCustomer.transform.position, ExitWaypoit.transform.position,1);
    }
    
    private void updatePositions() {
        for (int i = 0; i < theLine.Count; i++)
        {
            Debug.Log(theLine);
            GameObject currCustomer = theLine[i];
            Vector3 moveToPos = counterStart.transform.position;
            moveToPos.x = i * 2;
            currCustomer.transform.position = Vector3.Lerp(currCustomer.transform.position, moveToPos,1);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        theLine = new List<GameObject>();
        Debug.Log("X to add customer, C to complete first customer's order");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            addCustomer();
            updatePositions();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RemoveFirstCustomerInLine();
            updatePositions();
        }
        
    }

    private void FixedUpdate()
    {
        
    }
}
