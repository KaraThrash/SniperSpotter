using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotter : MonoBehaviour {
    public GameObject raycastObject;
    public GameObject marker;
    public GameObject lastmarker;
    public GameObject groundlocation;
    public GameObject skylocation;
    public GameObject fadeplane;

    public GameObject bullet;
    public GameObject windManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("joystick button 0"))
        { Debug.Log("button 0"); PlaceMarker(); }
        if (Input.GetKeyUp("joystick button 1"))
        { Debug.Log("button 1"); EyeInTheSky(); }
        if (Input.GetKeyUp("joystick button 3"))
        { Debug.Log("button 1"); EyeInTheSky(); }
    }

    public void PlaceMarker()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(raycastObject.transform.position, raycastObject.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (lastmarker != null)
            { Destroy(lastmarker); }

            if (hit.transform.tag == "Ground")
            {lastmarker =  Instantiate(marker,hit.point,marker.transform.rotation) as GameObject; }
        }
       

    }

    public void EyeInTheSky()
    {
        fadeplane.GetComponent<VRTeleportFade>().StartFade();
        if (transform.root.position == groundlocation.transform.position)
        { transform.root.position = skylocation.transform.position; transform.root.rotation = skylocation.transform.rotation; }
        else { transform.root.position = groundlocation.transform.position; transform.root.rotation = groundlocation.transform.rotation; }
    }
    public void FireMissile()
    {
        GameObject clone = Instantiate(bullet, raycastObject.transform.position, raycastObject.transform.rotation) as GameObject;
        clone.GetComponent<Bullet>().wind = windManager;
        clone.GetComponent<Rigidbody>().AddForce(raycastObject.transform.forward * 20, ForceMode.Impulse);
    }
}
