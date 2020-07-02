using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManage : MonoBehaviour
{
    public TDate T1Date;
    public TDate T2Date;
    public TDate T3Date;
    private TDate selectedTData;
    private int money = 1000;
    public Text moneytext;
    public Animator moneyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ChangeMoney(int change =0)
    {
        money += change;
        moneytext.text = "￥" + money;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Cube"));
                if (isCollider)
                {
                    Cube cube = hit.collider.GetComponent<Cube>();

                    if (/*selectedTData != null && */cube.turretGo == null)
                    {
                        //可以创建 
                        if (money > selectedTData.cost)
                        {
                            ChangeMoney(-selectedTData.cost);
                            cube.BuildTurret(selectedTData.turretPrefab);
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                }
            }
        }
    }
    public void OnT1Selected(bool isOn)
    {
        if (isOn)
        {
            selectedTData = T1Date;
        }
    }

    public void OnT2Selected(bool isOn)
    {
        if (isOn)
        {
            selectedTData = T2Date;
        }
    }
    public void OnT3Selected(bool isOn)
    {
        if (isOn)
        {
            selectedTData = T3Date;
        }
    }
}
