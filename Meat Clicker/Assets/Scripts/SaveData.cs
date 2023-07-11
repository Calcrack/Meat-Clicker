using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Variables VB;
    public EventText ET;
    public WorkerController WC;

    private void SaveToJson()
    {
        Data data = new Data();
        data.Meats = VB.Meats;
        data.Hits = VB.Hits;
        data.Click = VB.Click;
        data.InternalMeats = VB.InternalMeats;
        data.InternalHits = VB.InternalHits;
        data.HPS = VB.HPS;
        data.CompanyName = ET.CompanyName;
        data.hours = ET.hours;
        data.Days = ET.Days;
        data.WeekDays = ET.WeekDays;
        data.MonthDays = ET.MonthDays;
        data.Years = ET.Years;
        data.WorkerLevel = new IntList(WC.WorkerLevel);
        data.WorkerStaticLevel = new IntList(WC.WorkerStaticLevel);


        string json = JsonUtility.ToJson(data);
        string filePath = Application.dataPath + "/SaveMeat.json";
        System.IO.File.WriteAllText(filePath, json);
    }

    private void LoadFromJson()
    {
        string filePath = Application.dataPath + "/SaveMeat.json";
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            Data data = JsonUtility.FromJson<Data>(json);

            VB.Meats = data.Meats;
            VB.Hits = data.Hits;
            VB.Click = data.Click;
            VB.InternalMeats = data.InternalMeats;
            VB.InternalHits = data.InternalHits;
            VB.HPS = data.HPS;
            ET.CompanyName = data.CompanyName;
            ET.hours = data.hours;
            ET.Days = data.Days;
            ET.WeekDays = data.WeekDays;
            ET.MonthDays = data.MonthDays;
            ET.Years = data.Years;
            WC.WorkerLevel = data.WorkerLevel.values;
            WC.WorkerStaticLevel = data.WorkerStaticLevel.values;

        }
    }

    [System.Serializable]
    private class Data
    {
        public double Meats;
        public double Hits;
        public double Click;
        public double InternalMeats;
        public double InternalHits;
        public double HPS;
        public string CompanyName;
        public int hours;
        public int Days;
        public int WeekDays;
        public int MonthDays;
        public int Years;
        public IntList WorkerLevel;
        public IntList WorkerStaticLevel;

    }

    [System.Serializable]
    private class IntList
    {
        public List<int> values;

        public IntList(List<int> list)
        {
            values = list;
        }
    }

    private void Start()
    {
        LoadFromJson();
    }

    private void Update()
    {
        SaveToJson();
    }
}
