using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cameraMove : MonoBehaviour
{
    [SerializeField]
    private testPlayerController player;

    [SerializeField]
    private Transform start;
    
    [SerializeField]
    private Transform goal;
    
    [SerializeField]
    private int moveTime;

	float length;
	int a = 0;
    // Start is called before the first frame update
    void Start()
    {
    	length = 0;
    	a = 0;
        this.transform.position = new Vector3(start.position.x,start.position.y,start.position.z);

		length = Vector3.Distance(start.position , goal.position);
		length = length / ((float)moveTime*60);
        //this.transform.DOMove(goal.position, moveTime);
    }

    // Update is called once per frame
    void Update()
    {
    	if(player.getDeth() == true)
    	{
    		if(a ==0)
    		{    			
    			a = 1;
    		
	    		Vector3 pos = new Vector3(this.transform.position.x , this.transform.position.y,this.transform.position.z + 5);
		        this.transform.DOMove(pos, 5);
			}
    	}
    	else
    	{
    		this.transform.position = new Vector3(this.transform.position.x ,this.transform.position.y , this.transform.position.z + length);
    	}
    }
}
