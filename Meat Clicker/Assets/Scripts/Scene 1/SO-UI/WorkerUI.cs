using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkerUI : MonoBehaviour
{
    public int workerID;
    //UI
    public TMP_Text WorkerLevelDisp;
    public TMP_Text WorkerNameDisp;
    public TMP_Text WorkerBaseCostDisp;
    public Image ImageColor;
    public void HireWorkers()
    {
        WorkerController.Instance.HireWorker(workerID);
    }
}