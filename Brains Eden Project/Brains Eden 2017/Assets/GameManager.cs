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
    private GameObject[] PlayerPrefab;
    [SerializeField]
    private GameObject[] Batteries;


    //[SerializeField]
    // private UiManager UI;

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
    public GameObject UICanvas;

    private float selectionTimer;
    public Text T_timer;

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(this);
        Players = new GameObject[maxPlayers];
        playersReady = new bool[maxPlayers];

        gameTimer = 0;
        gameOverTimer = 0;
        gameOverCanvas.SetActive(false);
        UICanvas.SetActive(false);

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
                int j = i-1;
                if (Players[j] == null)
                {
					Players[j] = Instantiate(PlayerPrefab[j]);
                    Players[j].transform.position = PlayersStartingPoints[j].position;
                    Players[j].transform.rotation = PlayersStartingPoints[j].rotation;
                    Players[j].GetComponent<PlayerController>().playerNumber = i;
                  //  UI.containers[i-1] = Players[i - 1].GetComponent<EnergyContainerPlayer>();
                    Players[j].GetComponent<Movment>().enabled = false;
                    Players[j].GetComponent<PlayerController>().enabled = false;
                    Players[j].GetComponent<PlayerAiming>().lightning.GetComponent<LightningSpawner>().enabled = false;
                    Batteries[j].SetActive(true);
                }
                else
                {
                    //Set ready
                    playersReady[j] = !playersReady[j];
                }
            }
        }

        int readyNum = 0;
        int currPlayers = 0;
        for (int i = 0; i < maxPlayers; i++)
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

           
            if (selectionTimer>0&&selectionTimer<1)
            {
                T_timer.text = "3";
            }
            else if (selectionTimer > 1 && selectionTimer < 2)
            {
                T_timer.text = "2";
            }
            else if (selectionTimer > 2 && selectionTimer < 3)
            {
                T_timer.text = "1";
            }


            if (selectionTimer > 3.0f)
            {
                startGame();
            }
        }
        else
        {
            selectionTimer = 0.0f;
            T_timer.text = "Press A To Join!";
        }
    }

    private void startGame()
    {
        state = GameState.Game;
        playerSelectionCanvas.SetActive(false);
        UICanvas.SetActive(true);
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] != null)
            {
                Players[i].GetComponent<Movment>().enabled = true;
                Players[i].GetComponent<PlayerController>().enabled = true;
                Players[i].GetComponent<PlayerAiming>().lightning.GetComponent<LightningSpawner>().enabled = true;
            }
        }
    }

    public void endGame()
    {
        state = GameState.GameOver;
        for (int i = 0; i < maxPlayers; i++)
        {
            Players[i].GetComponent<Movment>().enabled = false;
            Players[i].GetComponent<PlayerAiming>().lightning.GetComponent<LightningSpawner>().enabled = false;
            Players[i].GetComponent<PlayerController>().enabled = false;
        }


    }

    private void UpdateGame()
    {
        gameTimer += Time.deltaTime;

        for (int i = 0; i < maxPlayers; i++)
        {
            if (Players[i] == null && playersReady[i])
            {
                Players[i] = Instantiate(PlayerPrefab[i]);
                Players[i].transform.position = PlayersStartingPoints[i].position;
                Players[i].transform.rotation = PlayersStartingPoints[i].rotation;
                Players[i].GetComponent<PlayerController>().playerNumber = i+1;
                Batteries[i].GetComponent<EnergyContainer>().changeEnergy(-50.0f);
            }
        }

        if (gameTimer >= gameTime)
        {
            //go to next state
            print("time finished");
            endGame();
        }
    }

    private void UpdateGameOver()
    {
        UICanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        bool continueSort = true;
        while (continueSort)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    if (Batteries[i].GetComponent<EnergyContainer>().energy < Batteries[j].GetComponent<EnergyContainer>().energy)
                    {
                        continueSort = true;
                        GameObject leftMost = Batteries[i];

                        Batteries[i] = Batteries[j];
                        Batteries[j] = leftMost;
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
                    child.gameObject.GetComponent<Text>().text = Batteries[0].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    Batteries[0].name;
                    break;
                case "2":
                    child.gameObject.GetComponent<Text>().text = Batteries[1].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    Batteries[1].name;
                    break;
                case "3":
                    child.gameObject.GetComponent<Text>().text = Batteries[2].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    Batteries[2].name;
                    break;
                case "4":
                    child.gameObject.GetComponent<Text>().text = Batteries[3].GetComponent<EnergyContainer>().energy.ToString() + " " +
                    Batteries[3].name;
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

    public int GetTimeLeft()
    {
        return Mathf.RoundToInt(gameTime - gameTimer);
    }
}