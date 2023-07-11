using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Drawing;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Importar Scripts
    public Variables VB;
    public MeatSelector MS;
    public List<MeatSO> ListMeatSO;
    public ParticleController PC;
    // Start is called before the first frame update
    void Start()
    {
        MS.SelectorMeats();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCounts();
        ReCount();
    }

    public void CookedMeats()
    {
        PC.ParticlesStart();
        VB.Hits += VB.Click;

        for (int i = 0; i < ListMeatSO.Count; i++)
        {
            if (VB.Hits >= ListMeatSO[i].Durability)
            {
                VB.Hits = 0;
                VB.Meats += 1;
                VB.InternalMeats += 1;
                MS.SelectorMeats();
            }
        }
    }
    public void UpdateCounts()
    {
        VB.HitsCount.text = Math.Truncate(VB.Hits).ToString("0") + "";
        VB.MeatsCount.text = Math.Truncate(VB.Meats).ToString("0") + "";
        VB.HPSCount.text = VB.HPS.ToString("0.0") + " HPS";
        VB.HitsCount.fontSize = 55;
        VB.MeatsCount.fontSize = 55;
        VB.HPSCount.fontSize = 55;
    }
    public void ReCount()
    {
        // Recuenta Meats
        if (VB.Meats >= 999999999999999)
        {
            VB.Meats = 0;
        }
        if (VB.Meats <= -1)
        {
            VB.Meats = 0;
        }

        // Recuenta Hits
        if (VB.Hits >= 999999999999999)
        {
            VB.Hits = 0;
        }
        if (VB.Hits <= -1)
        {
            VB.Hits = 0;
        }

    }
}