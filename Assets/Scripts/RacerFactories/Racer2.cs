using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer2 : AIRacer
{
    //public Racer2(Vector3 startPos)
    //{
    //    racerName = "Type 1";
    //    Initialize(startPos);
    //    maxSpeed = 300f;
    //    acceleration = 15f;
    //    //racerInstance.AddComponent<Racer1>();
    //}
    [SerializeField] GameObject NewAppearence;
    public override void AddInstance(Vector3 startPos)
    {
        racerName = "Type 2";
        maxSpeed = 150f;
        acceleration = 8f;
        appearence = (GameObject)Resources.Load("Car2");
        Initialize(startPos);
        //racerInstance.AddComponent<Racer1>();
    }
    private void OnEnable()
    {
        //Instantiate(NewAppearence, racerInstance.transform);
    }
}
