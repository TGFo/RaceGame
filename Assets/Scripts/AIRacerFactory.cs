using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerFactory : Factory
{
    enum type
    {
        type1,
        type2,
        type3
    }
    [SerializeField] Racer1 racer1;
    [SerializeField] Racer2 racer2;
    [SerializeField] Racer3 racer3;
    [SerializeField] GameObject defaultRacerPrefab;
    public override IRacer CreateRacer(int racerType)
    {
        IRacer racer;
        type typeRacer = (type)racerType;
        Debug.Log("check1");
        GameObject racerInstance = Instantiate(defaultRacerPrefab);
        Debug.Log("check2");
        switch (typeRacer)
        {
            case type.type1:
                racer = createRacer1(racer1, racerInstance);
            break;
            case type.type2:
                racer = createRacer2(racer2, racerInstance);
                break;
            case type.type3:
                racer = createRacer3(racer3, racerInstance);
            break;
            default:
                racer = null;
                Debug.Log("null");
            break;
        }
        return racer;
    }
    private IRacer createRacer1(AIRacer racer, GameObject instance)
    {
        racer = instance.AddComponent<Racer1>();
        Debug.Log(racer.name);
        return racer;
    }
    private IRacer createRacer2(AIRacer racer, GameObject instance)
    {
        racer = instance.AddComponent<Racer2>();
        Debug.Log(racer.name);
        return racer;
    }
    private IRacer createRacer3(AIRacer racer, GameObject instance)
    {
        racer = instance.AddComponent<Racer3>();
        Debug.Log(racer.name);
        return racer;
    }
}
