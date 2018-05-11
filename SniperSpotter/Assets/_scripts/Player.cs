using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject bullet;
    public GameObject gun;
    public GameObject windManager;
    public int speed;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) { Fire(); }
    }
    public void Fire()
    {
        GameObject clone = Instantiate(bullet, gun.transform.position, gun.transform.rotation)as GameObject;
        clone.GetComponent<Bullet>().wind = windManager;
        clone.GetComponent<Rigidbody>().AddForce(gun.transform.forward * speed,ForceMode.Impulse);
    }

}
