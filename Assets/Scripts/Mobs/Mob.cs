using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public abstract class Mob : MonoBehaviour
{
    private int health;
    private int damage;
    private Player player;
    private GameManager gameManager;
    private UIManager uiManager;
    public int fullHealth;
    public Slider mobHealthSlider;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
	void Start ()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mobHealthSlider.value = 1;
    }

    public abstract void SetStat(int health,int damage);

    public void Attack()
    {
        player.GetDamage(Random.Range(1,this.Damage));
        if (player.Health > 0)
            gameManager.ChangeTurn();
    }

    public void GetDamage(int damage)
    {
        this.Health -= damage;
        mobHealthSlider.value = (float)this.Health / (float)this.fullHealth;
        if (this.Health <= 0)
        {
            gameManager.ChangeState(State.newMobInWave);
            uiManager.MobsLeft();
            Destroy(gameObject);
        }
        else
            gameManager.ChangeTurn();
    }
}
