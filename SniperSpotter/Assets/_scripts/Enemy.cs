using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform[] patrol;
    private int Currentpoint;
    public float moveSpeed;
    public float footPrintClock;
    public GameObject arrow;
    public GameObject myFoot;
    public Vector3 dir = Vector3.zero;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Patrol();
       // if (footPrintClock > 0) { footPrintClock -= Time.deltaTime; }
	}

    public void Patrol()
    {
        
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(patrol[Currentpoint].position),
                Time.deltaTime * 35
            );
        
        if (transform.position == patrol[Currentpoint].position)
        {
           // Currentpoint++;

            Currentpoint = Random.Range(0, patrol.Length);
        }

        if (Currentpoint >= patrol.Length)
        {
            Currentpoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrol[Currentpoint].position, moveSpeed * Time.deltaTime);
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
