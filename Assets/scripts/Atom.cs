using UnityEngine;
using System.Collections.Generic;
using System;

public class Atom : MonoBehaviour {

    List<GameObject> electrons = new List<GameObject>();

    // Use this for initialization
    void Start () {
        Game.atom = this;
        initElectrons();
    }
	
	// Update is called once per frame
	void Update () {
        //orbiting(electron.transform, transform, 10);
        orbiting();
    }

    public void initElectrons()
    {
        int[] electronNumbers = Game.getCurrentLevel().electrons;
        int numberOfOrbits = electronNumbers.Length;
        for(int i = 0; i < numberOfOrbits; i++)
        {
            var electronsPerOrbit = electronNumbers[i];
            var nthOrbit = i + 1;
            var radius = nthOrbit * 2;
            for (int j = 0; j < electronsPerOrbit; j++)
            {
                var pos = findPosition(transform.position, radius, j, electronsPerOrbit);
                GameObject electron = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                electron.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                electron.transform.position = pos;
                electron.GetComponent<Renderer>().material.color = Color.blue;
                electron.tag = "electron";
                electrons.Add(electron);
            }
        }
    }

    public void removeElectrons()
    {
        foreach(GameObject electron in electrons)
        {
            Destroy(electron);
        }
        electrons = new List<GameObject>();
    }

    Vector3 findPosition(Vector3 center, int radius, int xth, int totalNumber)
    {
        var radian = Math.PI * 2 / totalNumber * xth;
        var cos = Math.Cos(radian);
        var sin = Math.Sin(radian);
        float x = (float)(radius * cos + center.x);
        float z = (float)(radius * sin + center.z);
        return new Vector3(x,0,z);
    }

    void orbiting()
    {
        foreach(GameObject electron in electrons)
        {
            electron.transform.RotateAround(transform.position, Vector3.up, 100 * Time.deltaTime);
        }
    }
}
