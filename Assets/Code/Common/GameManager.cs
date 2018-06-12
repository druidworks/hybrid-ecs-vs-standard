using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    private GameObject playerInstance;
    private Text ballCountText;
    private int ballCount = 0;

    private static GameManager gameManager;

	// Use this for initialization
	void Start () {
        playerInstance = Instantiate(playerPrefab);
        ballCountText = GameObject.Find("Scene Manager/Canvas/Ball Count").GetComponent<Text>();
	}
	
    public GameObject GetPlayerGameObjectInstance()
    {
        return playerInstance;
    }

    public void IncreaseBallCount()
    {
        ballCount++;
        UpdateBallCountText();
    }

    public void DecrementBallCount()
    {
        ballCount--;
        UpdateBallCountText();
    }

    public int GetBallCount()
    {
        return ballCount;
    }

    private void UpdateBallCountText()
    {
        ballCountText.text = "Ball Count: " + ballCount.ToString();
    }

    public static GameManager GetGameManagerInstance()
    {
        if (gameManager == null)
        {
            GameObject gameObject = GameObject.Find("Game Manager");
            if (gameObject)
            {
                gameManager = gameObject.GetComponent<GameManager>();
                return gameManager;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return gameManager;
        }        
    }

    public static GameObject GetPlayerInstance()
    {
        GameManager gm = GetGameManagerInstance();
        return gm.GetPlayerGameObjectInstance();
    }

    public static void IncreateBallCountText()
    {
        GameManager gm = GetGameManagerInstance();
        gm.IncreaseBallCount();
    }

    public static void DecrementBallCountText()
    {
        GameManager gm = GetGameManagerInstance();
        gm.DecrementBallCount();
    }

    public static int GetBallCountValue()
    {
        GameManager gm = GetGameManagerInstance();
        return gm.GetBallCount();
    }
}
