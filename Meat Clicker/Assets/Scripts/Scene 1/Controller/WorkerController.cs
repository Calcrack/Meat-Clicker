using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WorkerController : MonoBehaviour
{
    // Definir variables
    public WorkerUI workerPrefab;
    public Transform PanelPrefabs;
    // Importar scripts
    public GameController GC;
    public Variables VB;
    public static WorkerController Instance;
    public List<int> WorkerLevel;
    public List<int> WorkerStaticLevel;
    public List<WorkerSO> ListWorkerSO;
    public List<WorkerUI> ListWorkerUI;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (WorkerLevel == null || WorkerLevel.Count == 0)
        {
            WorkerLevel = new int[ListWorkerSO.Count].ToList();
        }
        if (WorkerStaticLevel == null || WorkerStaticLevel.Count == 0)
        {
            WorkerStaticLevel = new int[ListWorkerSO.Count].ToList();
        }
        for (int i = 0; i < ListWorkerSO.Count; i++)
        {
            WorkerUI worker = Instantiate(workerPrefab, PanelPrefabs);
            worker.workerID = i;
            ListWorkerUI.Add(worker);
        }
        UpdateHits();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ListWorkerSO.Count; i++)
        {
            VB.Hits += ListWorkerSO[i].WorkerPower * WorkerLevel[i] * Time.deltaTime;
        }
        UpdateColor();
    }
    public void UpdateColor()
    {
        for (int i = 0; i < ListWorkerSO.Count; i++)
        {
            if (CalculateCost(i) <= VB.Hits)
            {
                ListWorkerUI[i].ImageColor.color = Color.white;

            }
            else
            {
                ListWorkerUI[i].ImageColor.color = Color.red;
            }
        }
    }
    public void HireWorker(int ID)
    {
        if (CalculateCost(ID) <= VB.Hits)
        {
            VB.Hits -= CalculateCost(ID);
            WorkerLevel[ID] += 1;

            UpdateHits();
            HPSUpdate(ID);

        }
        else
        {
            ListWorkerUI[ID].ImageColor.color = Color.red;
        }
    }
    public void HPSUpdate(int ID)
    {
            if (WorkerLevel[ID] >= 1)
            {
                WorkerStaticLevel[ID] = 1;
                VB.HPS += ListWorkerSO[ID].WorkerPower * WorkerStaticLevel[ID];
            }
    }
    public void UpdateHits()
    {
        for (int i = 0; i < ListWorkerUI.Count; i++)
        {
            ListWorkerUI[i].WorkerLevelDisp.text = "" + WorkerLevel[i];
            ListWorkerUI[i].WorkerNameDisp.text = ListWorkerSO[i].WorkerName;
            ListWorkerUI[i].WorkerBaseCostDisp.text = "Costo: " + CalculateCost(i).ToString("0") + " Golpes";
        }
    }
    public float CalculateCost(int ID)
    {
        return (int)Math.Floor(ListWorkerSO[ID].WorkerBaseCost * Math.Pow(ListWorkerSO[ID].WorkerMultiplyCost, WorkerLevel[ID]));
    }
}