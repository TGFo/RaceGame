using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer1 : AIRacer
{
    /*public Racer1(Vector3 startPos)
    {
        racerName = "Type 1";
        Initialize(startPos);
        maxSpeed = 300f;
        acceleration = 15f;
        //racerInstance.AddComponent<Racer1>();
    }*/
    [SerializeField] GameObject NewAppearence;
    public override void AddInstance(Vector3 startPos)
    {
        racerName = "Type 1";
        maxSpeed = 50f;
        acceleration = 15f;
        appearence = (GameObject)Resources.Load("Car1");
        Initialize(startPos);
        //racerInstance.AddComponent<Racer1>();
    }
    private void OnEnable()
    {
        //Instantiate(NewAppearence, racerInstance.transform);
    }
}
