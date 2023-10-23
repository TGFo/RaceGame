using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRacer
{
    public void Initialize(Vector3 startPos);
    public void MoveTo(Vector3 position);
    public void AddInstance(Vector3 startPos);
}
