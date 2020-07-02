using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E1 : MonoBehaviour
{
    public float speed = 10;
    private Transform[] positions;
    private int index =0;
     void Start()
    {
        positions = WayPoint.positions;
    }
     void Update()
    {


        Move();
    }
    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
        void ReachDestination()
        {
            //Gamemanage.Instance.Failed();
            GameObject.Destroy(this.gameObject);
        }
    }
    void ReachDestination()
    {
        //Gamemanage.Instance.Failed();
        GameObject.Destroy(this.gameObject);
    }


    void OnDestroy()
    {
        ESpawner.CountEnemyAlive--;
    }
}
