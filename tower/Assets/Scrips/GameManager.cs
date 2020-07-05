using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;
    public Text endMessage;
    public static GameManager Instance;
    private ESpawner enemySpawner;
    public  int money = 500;
    public  Text moneytext;

    public static int addmoney = 0;


    public  void ChangeMoney(int change = 0)
    {
        //if (addmoney!= 0)
        //{
        //    money += addmoney;
        //    addmoney = 0;
        //}
        money += change;
        moneytext.text = money.ToString();
    }
    void Awake()
    {
        
        Instance = this;
        enemySpawner = GetComponent<ESpawner>();
    }
    private void Update()
    {
        if (addmoney != 0)
        {
            ChangeMoney(addmoney);
            addmoney = 0;
            
        }
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜 利";
    }
    public void Failed()
    {
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "失 败";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
