using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject customerSpawnPrefab;
    [SerializeField]
    public GameObject Waypoints;
    public bool buttonPressed = false;

    private List<GameObject> theLine;
    private List<Vector3> theLinePositons;
    private List<Vector3> ExitPath;
    private float startOfLineX;

    public float speed = 0.5f;
    
    

    /* What do: adds a customer with a random order
     * Input: Nothing
     * Output: Void
     */
    void addCustomer()
    {
        GameObject currCustomer = Instantiate(customerSpawnPrefab, Waypoints.transform.GetChild(0).transform.position, transform.rotation);
        theLine.Add(currCustomer);
    }
    
    /* What do: creates the line position arrays and Exit Path
     * Input: Nothing
     * Output: Void
     */
    void setUpLinesAndPaths()
    {
        
        theLine = new List<GameObject>();
        theLinePositons = new List<Vector3>();
        ExitPath = new List<Vector3>();
        
        theLinePositons.Add(Waypoints.transform.GetChild(4).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(3).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(2).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(1).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(0).transform.position);

        ExitPath.Add(Waypoints.transform.GetChild(7).transform.position);
        ExitPath.Add(Waypoints.transform.GetChild(6).transform.position);
        ExitPath.Add(Waypoints.transform.GetChild(5).transform.position);
    }
    

    
    public int numOfCustomer(){
        return theLine.Count;
    }
    
    /* What do: Removes the first person in line and sends them to the exit
     * Input: Nothing
     * Output: Void
     */
    private void RemoveFirstCustomerInLine()
    {
        if (theLine.Count > 0)
        {
            GameObject leavingCustomer = this.theLine[0];
            this.theLine.RemoveAt(0);
            
            leavingCustomer.GetComponent<prefabCustomer>().setTargetPosStack(ExitPath);
            //leavingCustomer.transform.position = Vector3.Lerp(leavingCustomer.transform.position, ExitWaypoit.transform.position,Time.deltaTime * speed);
        }

        
    }
    
    /* What do: Updates the customers position in the line
     * Input: Nothing
     * Output: Void
     */
    private void updatePositions() {
        if (theLine.Count > 0)
        {
            for (int i = 0; i < theLine.Count; i++)
            {
                Debug.Log(theLine);
                GameObject currCustomer = theLine[i];
                if (currCustomer.transform.position == Waypoints.transform.GetChild(0).transform.position)
                {
                    Debug.Log("Just Spawned");
                    List<Vector3> subPath = new List<Vector3>();
                    int spotTarget = 5 - i;
                    Debug.Log(spotTarget); 
                    //this is not creating the correct path, it is the same each time
                    for (int j = 0; j < spotTarget; j++)
                    {
                        subPath.Add(theLinePositons[j]);
                    }
                    
                    currCustomer.GetComponent<prefabCustomer>().setTargetPosStack(subPath);
                }
                else
                {
                    Debug.Log("Here");
                    Vector3 moveToPos = theLinePositons[i];   
                    currCustomer.GetComponent<prefabCustomer>().setTargetPos(moveToPos);
                }

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setUpLinesAndPaths();
        Debug.Log("X to add customer, C to complete first customer's order");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X) && this.theLine.Count < 5)
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
