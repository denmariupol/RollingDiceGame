using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private WaveManager waveManager;
    public State gameState;
    private Player player;
    private UIManager uiManager;
    private Mob mob;
    private int turnCount = 0;
    void Start ()
    {
        gameState = State.preWaveTime;
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
	}


    public void ChangeState(State state)
    {
        gameState = state;
    }


    public void ChangeTurn()
    {
        turnCount++;
        if (turnCount == 1)
            ChangeState(State.playerTurn);
        else
        {
            ChangeState(State.mobTurn);
            turnCount = 0;
        }
    }


    void Update ()
    {
	    switch(gameState)
        {
            case State.preWaveTime:
                waveManager.PreWaveCountDown();
                break;


            case State.newWave:
                waveManager.WaveConstructor();
                break;


            case State.newMobInWave:
                waveManager.PlaceMobs();
                break;


            case State.playerTurn:
                player.Attack();
                break;


            case State.mobTurn:
                mob.Attack();
                break;


            case State.playerWin:
                uiManager.PlayerWin();
                break;


            case State.playerLoose:
                uiManager.PlayerLoose();
                break;
        }
	}


    public void CurrentMob(Mob currentMob)
    {
        mob = currentMob;
    }
}
