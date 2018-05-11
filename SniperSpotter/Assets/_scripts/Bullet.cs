using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime;
    public GameObject wind;
    public float windSpeed;
    public Vector3 windDirection;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
       // wind = GameObject.Find("WindManager");
	}
	
	// Update is called once per frame
	void Update () {
        if (wind != null)
        { WindEffect(); }
     
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) { Destroy(this.gameObject); }
	}

    public void WindEffect()
    {windSpeed = wind.GetComponent<Wind>().windSpeed;
        windDirection = wind.GetComponent<Wind>().windDirection;
        rb.AddForce((windDirection) * windSpeed);
    }
}
