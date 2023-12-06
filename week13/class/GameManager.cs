using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText;
    void GetCoin()
    {
        coinCount++;
        coinText.text = coinCount + "";
        Debug.Log("동전 : " + coinCount);
    }
    // Start is called before the first frame update
    void RedCoinStart()
    {
        DestroyObstacles();
    }
    void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    

}
