using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public string[] DayNames;
    public int hours;
    public int days;
    // Start is called before the first frame update
    void Start()
    {
        DayNames = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
