using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportFade : MonoBehaviour {
    public Color colorStart = Color.red;
    public Color colorEnd = Color.clear;
    public Renderer fadematerial;
    public bool fade;
	// Use this for initialization
	void Start () {
        fadematerial = GetComponent<Renderer>();
        colorEnd.a = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //fadematerial.material.color != colorEnd ||
        if (fadematerial.material.color != colorEnd)
        {
            fadematerial.material.color = Color.Lerp(fadematerial.material.color, colorEnd, 0.2f);
            // fadematerial.material.color.a -= 0.1f;
        }
     
	}
    public void StartFade()
    {
        fadematerial.material.color = colorStart;
    }

}
