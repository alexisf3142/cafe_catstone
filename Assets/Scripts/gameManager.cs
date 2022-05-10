using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class gameManager : MonoBehaviour
{

    public GameObject Player;
    
    public GameObject customerSpawnPrefab;
    public GameObject customerSpawnPrefab2;
    public GameObject customerSpawnPrefab3;
    public GameObject customerSpawnPrefab4;
    private List<GameObject> customerSpawnPrefabList;
    public GameObject catPrefab1;
    public GameObject catPrefab2;
    [SerializeField]
    public GameObject Waypoints;
    public GameObject WaypointsForCats;
    public bool buttonPressed = false;

    private bool coffeeDone = false;
    private bool tringToCheckout = false;

    private List<GameObject> theLine;
    private List<GameObject> DeleteCustomers;
    private List<Vector3> theLinePositons;
    private List<Vector3> ExitPath;
    
    private List<GameObject> catsList;
    private List<Vector3> CatPath1;
    private List<Vector3> CatPath2;
    
    public GameObject ProfitTracker;
    public Animator animator;

    public GameObject Clock;
    
    public float speed = 0.5f;

    public AudioSource audioSource;
    public AudioClip CashRegister;
    public AudioClip DoorSound;
    public AudioClip SpillSound;
    public AudioClip MopSound;

    public bool AlmostEndPortrait = false;
    public bool EndPortrait = false;
    public GameObject Profile;
    public int CoffeeServed = 0;

    private int NumOfCoffeeServed = 0;
    public GameObject MainManager;
    public GameObject MenuUIHander;

    public int getNumOfCoffeeServed()
    {
        return NumOfCoffeeServed;
    }

    /* What do: adds a customer with a random order
     * Input: Nothing
     * Output: Void
     */
    private int lastCustomer = 4;
    int choosenCustomer = 0;
    void addCustomer()
    {
        
        if (lastCustomer == 4)
        {
            choosenCustomer = UnityEngine.Random.Range(0, 4);
            lastCustomer = choosenCustomer;
        }
        else
        {
            choosenCustomer = UnityEngine.Random.Range(0, 3);
            if (choosenCustomer == lastCustomer)
            {
                choosenCustomer = choosenCustomer + 1;
            }
            lastCustomer = choosenCustomer;
        }
        
        //add random things here
        GameObject currCustomer = Instantiate(customerSpawnPrefabList[choosenCustomer], Waypoints.transform.GetChild(0).transform.position, transform.rotation);
        theLine.Add(currCustomer);
        audioSource.clip = DoorSound;
        audioSource.Play();
        Profile.GetComponent<ProfileUpdated>().NewCustomer();
    }
    
    void addCat(GameObject cat, Vector3 spawn)
    {
        GameObject currCat= Instantiate(cat, spawn, transform.rotation);
        currCat.GetComponent<catMoving>().setPlayer(Player);
        catsList.Add(currCat);
        currCat.GetComponent<catMoving>().setTargetPos(spawn);
    }
    
    /* What do: creates the line position arrays and Exit Path and cat Paths
     * Input: Nothing
     * Output: Void
     */
    void setUpLinesAndPaths()
    {
        
        theLine = new List<GameObject>();
        theLinePositons = new List<Vector3>();
        ExitPath = new List<Vector3>();
        CatPath1 = new List<Vector3>();
        CatPath2 = new List<Vector3>();
        catsList = new List<GameObject>();
        DeleteCustomers = new List<GameObject>();
        customerSpawnPrefabList = new List<GameObject>();
        
        
        theLinePositons.Add(Waypoints.transform.GetChild(5).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(4).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(3).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(2).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(1).transform.position);
        theLinePositons.Add(Waypoints.transform.GetChild(0).transform.position);

        ExitPath.Add(Waypoints.transform.GetChild(8).transform.position);
        ExitPath.Add(Waypoints.transform.GetChild(7).transform.position);
        ExitPath.Add(Waypoints.transform.GetChild(6).transform.position);
        
        CatPath1.Add(WaypointsForCats.transform.GetChild(0).transform.position);
        CatPath1.Add(WaypointsForCats.transform.GetChild(1).transform.position);
        CatPath1.Add(WaypointsForCats.transform.GetChild(2).transform.position);
        
        CatPath2.Add(WaypointsForCats.transform.GetChild(3).transform.position);
        CatPath2.Add(WaypointsForCats.transform.GetChild(4).transform.position);
        CatPath2.Add(WaypointsForCats.transform.GetChild(5).transform.position);
        CatPath2.Add(WaypointsForCats.transform.GetChild(6).transform.position);
        
        customerSpawnPrefabList.Add(customerSpawnPrefab);
        customerSpawnPrefabList.Add(customerSpawnPrefab2);
        customerSpawnPrefabList.Add(customerSpawnPrefab3);
        customerSpawnPrefabList.Add(customerSpawnPrefab4);
    }
    

    
    public int numOfCustomer(){
        return theLine.Count;
    }

    public void checkOutCustomer()
    {
        RemoveFirstCustomerInLine();
        updatePositions(); 
        hidePlayerCup();
        ProfitTracker.GetComponent<ProfitsTracker>().addToProfits(5f);
        coffeeDone = false;
        audioSource.clip = CashRegister;
        audioSource.Play();
        CoffeeServed += 1;
        Profile.GetComponent<ProfileUpdated>().UpdateCoffeeCount(CoffeeServed);
        Clock.GetComponent<clockScript>().UpdateClock();
        NumOfCoffeeServed = NumOfCoffeeServed + 1;

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
            DeleteCustomers.Add(leavingCustomer);
        }
    }

    private void deleteLeavingCustomers()
    {
        if (DeleteCustomers.Count > 0)
        {
            for (int i = 0; i < DeleteCustomers.Count; i++)
            {
                GameObject curr = DeleteCustomers[i];
                if (curr.transform.position == Waypoints.transform.GetChild(8).transform.position)
                {
                    DeleteCustomers.Remove(curr);
                    Destroy(curr);
                }   
            }    
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
                    int spotTarget = 5;
                    Debug.Log(spotTarget); 
                    //this is not creating the correct path, it is the same each time
                    for (int j = i; j < spotTarget; j++)
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

    private void updateCatPath1(GameObject cat)
    {
        if (cat.transform.position == CatPath1[2])
        {
            cat.GetComponent<catMoving>().setTargetPos(CatPath1[0]);
        }
        
        if (cat.transform.position == CatPath1[1])
        {
            cat.GetComponent<catMoving>().setTargetPos(CatPath1[0]);
        }

        if (cat.transform.position == CatPath1[0])
        {
            generator gen = new generator();
            if (gen.returnRandomBool())
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath1[1]);
            }
            else
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath1[2]);
            }
        }
    }
    
    private void updateCatPath2(GameObject cat)
    {
        generator gen = new generator();
        
        if (cat.transform.position == CatPath2[0])
        {
            if (gen.returnRandomBool())
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[1]);
            }
            else
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[3]);
            }
        }
        if (cat.transform.position == CatPath2[1])
        {
            if (gen.returnRandomBool())
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[0]);
            }
            else
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[2]);
            }
            
        }
        if (cat.transform.position == CatPath2[2])
        {
            if (gen.returnRandomBool())
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[1]);
            }
            else
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[3]);
            }
        }
        if (cat.transform.position == CatPath2[3])
        {
            if (gen.returnRandomBool())
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[0]);
            }
            else
            {
                cat.GetComponent<catMoving>().setTargetPos(CatPath2[2]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Clock.GetComponent<clockScript>().setClockCustomerCount(numOfCustomersPerDay);
        hidePlayerCup();
        setUpLinesAndPaths();
        addCat(catPrefab1, CatPath1[2]);
        addCat(catPrefab1, CatPath2[3]);
        Debug.Log("X to add customer, C to complete first customer's order");
    }

    public void setCoffeeDone(bool stat)
    {
        this.coffeeDone = stat;
    }
    
    public void setTringToCheckout(bool stat)
    {
        this.tringToCheckout = stat;
    }
    
    public void hidePlayerCup()
    {
        Player.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = -1;
        animator.SetBool("Holding", false);
    }
    
    public void showPlayerCup()
    {
        Player.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 11;
        animator.SetBool("Holding", true);
    }

    public bool isPlayerHoldingCup()
    {
        if (coffeeDone)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }
    
    //run Event
    private bool waitingForEvent = false;
    private bool endOfDay = false;
    private int numOfCustomersPerDay = 5;

    public int getCurrNumOfCustomersLeft()
    {
        return numOfCustomersPerDay;
    }

    IEnumerator  Wait()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("------------------Event!--------------------");
        Debug.Log(numOfCustomersPerDay);
        if (!endOfDay)
        {
            int determineEvent = UnityEngine.Random.Range(0, 100);
            if (determineEvent < 64)
            {
                //add customer
                addCustomer();
                updatePositions();
                //update player Counter in here
                numOfCustomersPerDay = numOfCustomersPerDay - 1;
            }
            else
            {
                //add spill
                GetComponent<SpillManager>().SpillCoffee();
                audioSource.clip = SpillSound;
                audioSource.Play();
            }
            waitingForEvent = false;
            
        }
        else
        {
            //Finish up message here

            if (theLine.Count == 0 && GetComponent<SpillManager>().getNumberOfSpills() == 0)
            {
                //Run Day is Ended And Everything is done
                Debug.Log("-----------END OF DAY-------------");
                Profile.GetComponent<ProfileUpdated>().EndOfDay();
                EndPortrait = true;
                MainManager.GetComponent<MainManager>().savePlayerData_EndOfDay();
                waiter();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
            }
            
            else
            {
                Debug.Log("ALMOST END OF DAY");
                if (AlmostEndPortrait == false)
                {
                    Profile.GetComponent<ProfileUpdated>().AlmostEndOfDay();
                    EndPortrait = true;
                }
            }
            waitingForEvent = false;
        }
    }
    
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(10);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfCustomersPerDay == 0)
        {
            endOfDay = true;
        }

        if (!waitingForEvent)
        {
            waitingForEvent = true;
            StartCoroutine (Wait());
        }


        if (Input.GetKeyDown(KeyCode.X) && this.theLine.Count < 5)
        {
            addCustomer();
            updatePositions();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GetComponent<SpillManager>().tryToClean(Player.transform.position))
            {
                audioSource.clip = MopSound;
                audioSource.Play();
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            RemoveFirstCustomerInLine();
            updatePositions();
        }

        updateCatPath1(catsList[0]);
        updateCatPath2(catsList[1]);
        deleteLeavingCustomers();

        if (coffeeDone)
        {
            //Debug.Log("Coffee Made!");
            showPlayerCup();
        }
        
        if (tringToCheckout)
        {
            Debug.Log("Check out Time!");
            tringToCheckout = false;
        }

    }

    private void FixedUpdate()
    {
        
    }
}
