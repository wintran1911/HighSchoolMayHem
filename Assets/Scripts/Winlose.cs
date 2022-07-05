using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Winlose : MonoBehaviour
{
    public static int intWin_lose;
    public GameObject scrLose;
    public GameObject scrWin;
    public int Rewardscoin;
    public  static int intRound =1;
    public TextMeshProUGUI txtRewardcoin;
    public TextMeshProUGUI txtRound;
    public static int lose;
    public static int win;
    public bool winorlose;
    // Start is called before the first frame update
    void Start()
    {
        scrLose.SetActive(false);
        scrWin.SetActive(false);
        intWin_lose = 0;
        txtRewardcoin.text = "" + Rewardscoin;
        Debug.Log(intWin_lose);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(intWin_lose);
        txtRound.text = "ROUND" + intRound;
        winORlose();
    }
    public void winORlose()
    {
       if(!winorlose)
        {
            if (win == 1 || lose == 1)
            {

                if (intWin_lose == 1)
                {

                    StartCoroutine(Onreset());
                    Debug.Log("load scene");
                }

            }
        }    
        if(win==1&&lose==1)
        {
            winorlose = true;
        }    
        if (lose == 2)
        {
           // if(Enemy.enemylose)
            {

              StartCoroutine(OnLose());
              Debug.Log("player thua");
              Enemy.enemylose = false;
            }    
         
        }
        else
        {
            if (win == 2)
            {
                StartCoroutine(OnWin());
                Debug.Log("player win");

            }
        }
        if(lose == 2 || win == 2)
        {
            Debug.Log("current" + intWin_lose);
            StartCoroutine(Reloadgame());
            intWin_lose = 0;
        }
    }  
   
    IEnumerator Reloadgame()
    {
        yield return new WaitForSeconds(3f);
        
        win = 0;
        lose = 0;
        intRound = 1;
    }
    IEnumerator OnLose()
    {
        yield return new WaitForSeconds(3f);
        scrLose.SetActive(true);
        scrWin.SetActive(false);
        Time.timeScale = 0;
    }
    IEnumerator OnWin()
    {
        yield return new WaitForSeconds(3f);
        scrLose.SetActive(false);
        scrWin.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator Onreset()
    {
        yield return new WaitForSeconds(3f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex);
        intRound++;
    }
    
}
