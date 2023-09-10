using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Material completedCheckPointMat;
    public Material nextCheckPointMat;
    public Stack<GameObject> checkPointStack = new Stack<GameObject>();
    [SerializeField] private CheckPointCollide[] checkPointArray;
    [SerializeField] private GameObject CheckPointsParent;
    [SerializeField] private float beginTimer = 10;
    [SerializeField] private float timer;
    private void Start()
    {
        Time.timeScale = 1f;
        timer = beginTimer;
        checkPointArray = CheckPointsParent.GetComponentsInChildren<CheckPointCollide>();
        Debug.Log(checkPointArray.Length);
        foreach(CheckPointCollide checkPoint in checkPointArray)
        {
            checkPointStack.Push(checkPoint.gameObject);
        }
        checkPointStack.Peek().GetComponent<Renderer>().material = nextCheckPointMat;
    }

    private void FixedUpdate()
    {
        timer = timer - Time.fixedDeltaTime;
    }
    public void TriggerCheckpoint(GameObject passedCheckpoint)
    {
        if (passedCheckpoint = checkPointStack.Peek())
        {
            checkPointStack.Peek().GetComponent<CheckPointCollide>().pointTriggered = true;
            GameObject currentCheckPoint = checkPointStack.Pop();
            GameObject nextCheckPoint = checkPointStack.Peek();
            currentCheckPoint.GetComponent<Renderer>().material = completedCheckPointMat;
            nextCheckPoint.GetComponent<Renderer>().material = nextCheckPointMat;
            Debug.Log("passed checkpoint: " + currentCheckPoint.name);
            timer += 10;
        }
    }
    public float GetTimer() { return timer; }
    public void SetTimer(float timer) { this.timer = timer; }
}
