using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool[] playersReady;

    public int maxPlayers;

    public float gameTime;
    private float gameTimer;

    public float gameOverTime;
    private float gameOverTimer;

    public GameObject playerSelectionCanvas;
    public GameObject gameOverCanvas;

    public GameObject[] bats;

    private float selectionTimer;

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(this);
        Players = new GameObject[maxPlayers];
        playersReady = new bool[maxPlayers];

        gameTimer = 0;
        gameOverTimer = 0;
        gameOverCanvas.SetActive(false);

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
                    UI.containers[i-1] = Players[i - 1].GetComponent<EnergyContainerPlayer>();
                    Players[i - 1].GetComponent<Movment>().enabled = false;
                    Players[i-1].GetComponentInChildren<LightningSpawner>().enabled = false;
                    Players[i - 1].GetComponent<PlayerController>().enabled = false;
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
        
        if (readyNum == currPlayers && currPlayers >=2)
        {
            selectionTimer += Time.deltaTime;
            if (selectionTimer > 3.0f)
            {
                startGame();
            }
        }
        else
        {
            selectionTimer = 0.0f;
        }
    }

    private void startGame()
    {
        state = GameState.Game;
        playerSelectionCanvas.SetActive(false);
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] != null)
            {
                Players[i].GetComponent<Movment>().enabled = true;
                Players[i].GetComponent<PlayerController>().enabled = true;
                Players[i].GetComponentInChildren<LightningSpawner>().enabled = true;
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
        UI.gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);

        bool continueSort = true;
        while (continueSort)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    if (bats[i].GetComponent<EnergyContainer>().energy < bats[j].GetComponent<EnergyContainer>().energy)
                    {
                        continueSort = true;
                        GameObject leftMost = bats[i];

                        bats[i] = bats[j];
                        bats[j] = leftMost;
                    }
                    else continueSort = false;
                }
            }
        }

        foreach (Transform child in gameOverCanvas.transform)
        {
            switch (child.gameObject.name)
            {
                case "1":
                    child.gameObject.GetComponent<Text>().text = bats[0].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    bats[0].name;
                    break;
                case "2":
                    child.gameObject.GetComponent<Text>().text = bats[1].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    bats[1].name;
                    break;
                case "3":
                    child.gameObject.GetComponent<Text>().text = bats[2].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    bats[2].name;
                    break;
                case "4":
                    child.gameObject.GetComponent<Text>().text = bats[3].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    bats[3].name;
                    break;
                default:
                    break;
            }
        }
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