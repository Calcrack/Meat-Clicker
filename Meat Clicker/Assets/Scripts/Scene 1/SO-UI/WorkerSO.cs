using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Workers", menuName = "SO/Workers")]
public class WorkerSO : ScriptableObject
{
    public string WorkerName;
    public double WorkerPower;
    public double WorkerBaseCost;
    public double WorkerMultiplyCost;
}
