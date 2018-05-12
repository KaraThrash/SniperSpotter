using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform[] patrol;
    public Transform patrolparent;
    public Vector3 patroltargetposition;
    public int Currentpoint;
    public float moveSpeed;
    public float rotspeed;
    public float footPrintClock;
    public GameObject arrow;
    public GameObject myFoot;
    public Vector3 dir = Vector3.zero;
    public float changedirectionclock;
    public float turnclock;
    public RaycastHit hit;

    // Use this for initialization
    void Start () {
       
        Currentpoint = Random.Range(0, patrolparent.childCount);
        patroltargetposition = patrolparent.GetChild(Currentpoint).transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Patrol();
       // if (footPrintClock > 0) { footPrintClock -= Time.deltaTime; }
	}

    public void Patrol()
    {
        changedirectionclock -= Time.deltaTime;
            
        
        if (Vector3.Distance(transform.position , patroltargetposition) < 5 || changedirectionclock < 0)
        {
            // Currentpoint++;
            changedirectionclock = Random.Range(5,20);
             Currentpoint = Random.Range(0, patrolparent.childCount);
            patroltargetposition = patrolparent.GetChild(Currentpoint).transform.position;
            
        }
        
        if (Currentpoint >= patrolparent.childCount)
        {
            Currentpoint = 0;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            turnclock = 0.5f;
         // Turn();

        }

        if (turnclock >= 0.5)
        {
            Turn();

        }
        else if (turnclock > 0) { turnclock -= Time.deltaTime; transform.position += transform.forward * moveSpeed * Time.deltaTime; }
        else { Move(); }
    }

    public void Move()
    {
       transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, patroltargetposition, moveSpeed * Time.deltaTime);
        Vector3 relativePos = patroltargetposition - transform.position;
        Quaternion targetrot = Quaternion.LookRotation(relativePos);
       

        transform.rotation = Quaternion.Slerp(
                transform.rotation,
               targetrot,
                Time.deltaTime * rotspeed
            );
    }
    public void Turn()
    {
        turnclock -= Time.deltaTime;
       // transform.position += transform.forward * 1.0f * Time.deltaTime;
        transform.Rotate(Vector3.up * 15 * Time.deltaTime);

       

    }





public void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.tag == "Bullet") { Destroy(this.gameObject); }
    }
    public void OnCollisionStay(Collision collision2)
    {
       // if (collision2.gameObject.tag == "Ground" && footPrintClock <= 0) { Instantiate(arrow, myFoot.transform.position, myFoot.transform.rotation); footPrintClock = 2; }
       
    }
}
