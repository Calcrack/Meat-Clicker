using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSelector : MonoBehaviour
{
    public GameController GC;
    public Variables VB;
    public void SelectorMeats()
    {
        if (VB.InternalMeats == 0)
        {
            VB.Meat = Resources.Load<MeatSO>("Meats/Meat 1");
            GC.ListMeatSO.Add(VB.Meat as MeatSO);
        }
        if (VB.InternalMeats == 1)
        {
            GC.ListMeatSO.Remove(VB.Meat as MeatSO);
            VB.Meat = Resources.Load<MeatSO>("Meats/Meat 2");
            GC.ListMeatSO.Add(VB.Meat as MeatSO);
        }
        if (VB.InternalMeats == 2)
        {
            GC.ListMeatSO.Remove(VB.Meat as MeatSO);
            VB.Meat = Resources.Load<MeatSO>("Meats/Meat 3");
            GC.ListMeatSO.Add(VB.Meat as MeatSO);
        }
    }
}
