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
    //private GameObject selectedTurretGo;
    public Animator moneyAnimator;
    private Cube selectedCube;
    public GameObject upgradeCanvas;
    private Animator upgradeCanvasAnimator;
    public Button buttonUpgrade;
    // Start is called before the first frame update
    public GameManager gameManager;

    
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
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

                    if (selectedTData != null && cube.turretGo == null)
                    {
                        //可以创建 
                        if (gameManager.money > selectedTData.cost)
                        {
                            gameManager.ChangeMoney(-selectedTData.cost);
                            cube.BuildTurret(selectedTData);
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (cube.turretGo != null)
                    {

                        // 升级处理

                        //if (mapCube.isUpgraded)
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, true);
                        //}
                        //else
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, false);
                        //}
                        if (cube == selectedCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            ShowUpgradeUI(cube.transform.position, cube.isUpgraded);
                        }
                        selectedCube = cube;
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
    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        //upgradeCanvas.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        if (gameManager.money >= selectedCube.turretData.costUpgraded)
        {
            gameManager.ChangeMoney(-selectedCube.turretData.costUpgraded);
            selectedCube.UpgradeTurret();
        }
        else
        {
            moneyAnimator.SetTrigger("Flicker");
        }

        StartCoroutine(HideUpgradeUI());
    }
    public void OnDestroyButtonDown()
    {
        selectedCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
}
