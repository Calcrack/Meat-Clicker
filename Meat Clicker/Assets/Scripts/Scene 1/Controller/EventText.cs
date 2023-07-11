using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public class EventText : MonoBehaviour
{
    public string CompanyName = "";
    public TMP_InputField CompanyNameTxt;
    public Image Background;
    public Image BackgroundCounter;
    public Image BackgroundMeat;

    public string[] dayNames;
    public string[] MonthNames;

    public int hours;
    public int Days = 1;
    public int WeekDays;
    public int MonthDays;
    public int Years = 2023;
    public TMP_Text TimeText;
    // Start is called before the first frame update
    void Start()
    {
        dayNames = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
        MonthNames = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio,", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        if (hours >= 25)
        {
            Background.color = ColorUtility.TryParseHtmlString("#002B2B", out Color color) ? color : Color.white;
            BackgroundCounter.color = ColorUtility.TryParseHtmlString("#002B2B", out Color color1) ? color : Color.white;
            BackgroundMeat.color = ColorUtility.TryParseHtmlString("#002B2B", out Color color2) ? color : Color.white;
        }
        else
        {
            Background.color = ColorUtility.TryParseHtmlString("#008080", out Color color) ? color : Color.white;
            BackgroundCounter.color = ColorUtility.TryParseHtmlString("#008080", out Color color1) ? color : Color.white;
            BackgroundMeat.color = ColorUtility.TryParseHtmlString("#008080", out Color color2) ? color : Color.white;
        }
        StartCoroutine(TimeUpdate());

    }

    // Update is called once per frame
    void Update()
    {
        CompanyName = CompanyNameTxt.text;
        CompanyNameTxt.text = CompanyName;
    }
    public IEnumerator TimeUpdate()
    {
        while (true)
        {
            hours += 1;
            if (hours >= 50)
            {
                hours = 0;
                Days += 1;
                WeekDays += 1;
                if (WeekDays == 6)
                {
                    WeekDays = 0;
                }
                if (Days > 31)
                {
                    Days = 1;
                    MonthDays += 1;
                }
                if (MonthDays > 11)
                {
                    MonthDays = 0;
                    Years += 1;
                }
            }
            if (hours <= 25)
            {
                Background.color = ColorUtility.TryParseHtmlString("#008080", out Color color) ? color : Color.white;
                BackgroundCounter.color = ColorUtility.TryParseHtmlString("#008080", out Color color1) ? color : Color.white;
                BackgroundMeat.color = ColorUtility.TryParseHtmlString("#008080", out Color color2) ? color : Color.white;
            }
            else
            {
                Background.color = ColorUtility.TryParseHtmlString("#002B2B", out Color color) ? color : Color.white;
                BackgroundCounter.color = ColorUtility.TryParseHtmlString("#002B2B", out Color color1) ? color : Color.white;
                BackgroundMeat.color = ColorUtility.TryParseHtmlString("#002B2B", out Color color2) ? color : Color.white;
            }
            string timeFormat = "{0}, {1} de {2} de {3}";
            string timeString = string.Format(timeFormat, dayNames[WeekDays], Days, MonthNames[MonthDays], Years);
            TimeText.text = timeString;
            yield return new WaitForSeconds(1);
        }
    }
}