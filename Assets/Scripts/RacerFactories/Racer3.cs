using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer3 : AIRacer
{
    //public Racer3(Vector3 startPos)
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
        racerName = "Type 3";
        maxSpeed = 100f;
        acceleration = 10f;
        appearence = (GameObject)Resources.Load("Car3");
        Initialize(startPos);
        //racerInstance.AddComponent<Racer1>();
    }
    private void OnEnable()
    {
        //Instantiate(NewAppearence, racerInstance.transform);
    }
}
