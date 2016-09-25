using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    private GameManager gameManager;
    private Ground ground;
    private UIManager uiManager;

    private int totalWaves = 5;
    private int waveCounter = 0;
    private float preWaveCounter = 5;
    
    public List<Mob> waveMobs = new List<Mob>();
    public GameObject[] mobs;
    public int TotalWaves
    {
        get { return totalWaves; }
        set { totalWaves = value; }
    }
    public int WaveCounter
    {
        get { return waveCounter; }
        set { waveCounter = value; }
    }
    public float PreWaveCounter
    {
        get { return preWaveCounter; }
        set { preWaveCounter = value; }
    }
    void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ground = GameObject.Find("Ground").GetComponent<Ground>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }


    public void PreWaveCountDown()
    {
        if (WaveCounter == 5)
            gameManager.ChangeState(State.playerWin);

        PreWaveCounter -= Time.deltaTime;
        uiManager.PreWaveTimer((int)PreWaveCounter);
        uiManager.Wave(WaveCounter);
        if (PreWaveCounter < 0)
        {
            PreWaveCounter = 5;
            WaveCounter++;
            uiManager.Wave(WaveCounter);
            uiManager.HidePreWaveTimer();
            gameManager.ChangeState(State.newWave);
        }
    }


    public void WaveConstructor()
    {
        switch (WaveCounter)
        {
            case 1:
                CreateMobs(new int[] { 1 });
                break;
            case 2:
                CreateMobs(new int[] { 2 });
                break;
            case 3:
                CreateMobs(new int[] { 2,1 });
                break;
            case 4:
                CreateMobs(new int[] { 3,2 });
                break;
            case 5:
                CreateMobs(new int[] { 4,3 });
                break;

        }
    }


    private void CreateMobs(int[] mobCount)
    {
        int c = 0;
        for (int i = 0; i < mobCount.Length; i++)
            c += mobCount[i];

        uiManager.MobsInWave(c);

        if (mobCount.Length > 0)
        {
            for (int i = 0; i < mobCount[0]; i++)
            {
                GameObject g = Instantiate(mobs[0], new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
                g.GetComponent<Mob>().SetStat(10, 2);
                waveMobs.Add(g.GetComponent<Mob>());
            }
        }

        if (mobCount.Length > 1)
        {
            for (int i = 0; i < mobCount[1]; i++)
            {
                GameObject g = Instantiate(mobs[1], new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
                waveMobs.Add(g.GetComponent<Mob>());
                g.GetComponent<Mob>().SetStat(30, 6);
            }
        }

        gameManager.ChangeState(State.newMobInWave);
    }


    Mob SearchMob()
    {
        Mob1 mob1 = (Mob1)FindObjectOfType(typeof(Mob1));
        Mob2 mob2 = (Mob2)FindObjectOfType(typeof(Mob2));

        if (mob1)
            return mob1;
        else if (mob2)
            return mob2;
        else
            return null;
    }


    public void PlaceMobs()
    {
        var searchedMob = SearchMob();
        int randomTile;
        if (!searchedMob)
        {
            gameManager.ChangeState(State.preWaveTime);
            return;
        }
        gameManager.CurrentMob(searchedMob);
        randomTile = Random.Range(0, 24);
        for (int i = 0;i < ground.tiles.Count;i++)
        {
            if (i == randomTile)
            {
                searchedMob.transform.position = 
                    new Vector3(ground.tiles[i].transform.position.x, ground.tiles[i].transform.position.y + searchedMob.transform.localScale.y, ground.tiles[i].transform.position.z);
                gameManager.ChangeTurn();
            }
        }

    }
    

}
