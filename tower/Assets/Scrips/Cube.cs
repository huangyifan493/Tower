using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void BuildTurret(GameObject turretPrefab)
    {
        GameObject.Instantiate(turretPrefab, transform.position, Quaternion.identity);
    }
}
