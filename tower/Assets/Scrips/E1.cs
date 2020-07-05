using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E1 : MonoBehaviour
{
    public GameObject explosionEffect;
    public float speed = 8;
    public float hp = 150;
    private float totalHp;
    public Slider hpSlider;
    private Transform[] positions;
    private int index = 0;
    public Transform forword;
    //private BuildManage addmoney;
   

    void Start()
    {
        
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
        positions = WayPoint.positions;
    }
     void Update()
    {
        
        if ( positions[0] != null)
        {
            Vector3 targetPosition = positions[index].transform.position;
            targetPosition.y = forword.position.y;
            forword.LookAt(targetPosition);
        }
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
        
    }

    
    void ReachDestination()
    {
        GameManager.Instance.Failed();
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        ESpawner.CountEnemyAlive--;
        GameManager.addmoney=50;

    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0)return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        
        Destroy(this.gameObject);
    }
}
