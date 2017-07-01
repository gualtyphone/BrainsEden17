using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Selection,
    Game,
    GameOver,
    Return
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    [SerializeField]
    private UiManager UI;

    public GameState state = GameState.Selection;

    public GameObject[] Players;
    public Transform[] PlayersStartingPoints;
    protected bool[] playersReady;

    public int maxPlayers;

    public float gameTime;
    private float gameTimer;

    public float gameOverTime;
    private float gameOverTimer;

    public GameObject gameCanvas;
    public GameObject gameOverCanvas;

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(this);
        Players = new GameObject[maxPlayers];
        playersReady = new bool[maxPlayers];

        gameTimer = 0;
        gameOverTimer = 0;

        for (int i = 0; i < playersReady.Length; i++)
        {
            playersReady[i] = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case GameState.Selection:
                UpdateSelection();
                break;

            case GameState.Game:
                UpdateGame();
                break;

            case GameState.GameOver:
                UpdateGameOver();
                break;

            case GameState.Return:
                Destroy(gameObject);
                SceneLoader.m_sceneLoader.LoadMainMenu();
                break;
        }
    }

    private void UpdateSelection()
    {
        for (int i = 1; i <= Mathf.Min(maxPlayers, Input.GetJoystickNames().Length); i++)
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + i + "Button0")))
            {
                if (Players[i - 1] == null)
                {
                    Players[i - 1] = Instantiate(PlayerPrefab);
                    Players[i - 1].transform.position = PlayersStartingPoints[i - 1].position;
                    Players[i - 1].transform.rotation = PlayersStartingPoints[i - 1].rotation;
                    Players[i - 1].GetComponent<PlayerController>().playerNumber = i;
                    UI.containers[i - 1] = Players[i - 1].GetComponent<EnergyContainerPlayer>();
                }
                else
                {
                    //Set ready
                    playersReady[i - 1] = !playersReady[i - 1];
                }
            }
        }

        int readyNum = 0;
        int currPlayers = 0;
        for (int i = 1; i <= Mathf.Min(maxPlayers, Input.GetJoystickNames().Length); i++)
        {
            if (Players[i] != null)
            {
                currPlayers++;
                if (playersReady[i])
                {
                    readyNum++;
                }
            }
        }
    }

    private void UpdateGame()
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= gameTime)
        {
            //go to next state
            print("time finished");
            state = GameState.GameOver;
        }
    }

    private void UpdateGameOver()
    {
        gameCanvas.SetActive(false);
        gameOverTimer += Time.deltaTime;
        if (gameOverTimer >= gameOverTime)
        {
            //go to next state
            print("time finished");
            state = GameState.Return;
        }
    }

    private void Timer(float _timer, float _time, GameState _nextState)
    {
        _timer += Time.deltaTime;
        print(_timer);
        if (_timer >= _time)
        {
            //go to next state
            print("time finished");
            state = _nextState;
        }
    }
}