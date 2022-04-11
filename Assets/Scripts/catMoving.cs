using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMoving : MonoBehaviour
{
    private Stack<Vector3> movingStack = new Stack<Vector3>();
    private Vector3 targetPos;
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        if (this.movingStack.Count != 0)
        {
            if (transform.position == this.movingStack.Peek())
            {
                movingStack.Pop();
                if (this.movingStack.Count != 0)
                {
                    targetPos = this.movingStack.Peek();  
                }
            }   
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    
    
    /* What do: Moves customer to a point
     * Input: a Vector3 position
     * Output: Void
     */
    public void setTargetPos (Vector3 target)
    {
        this.targetPos = target;
    }
    
    /* What do: Moves customer through a list of points
     * Input: A list of points for the customer to move through in-order
     * Output: Void
     */
    public void setTargetPosStack (List<Vector3> targetList)
    {
        /*for (int i = targetList.Count-1; i > 0; i++)
        {
            movingStack.Push(targetList[i]);
        }*/

        for (int i = 0; i < targetList.Count; i++)
        {
            movingStack.Push(targetList[i]);
        }

        targetPos = this.movingStack.Peek();

    }
}
