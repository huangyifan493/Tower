using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TDate
{ 
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradedPrefab;
    public int costUpgraded;
    public TurretType type;
}
public enum TurretType
{
    T1,
    T2,
    T3
}
