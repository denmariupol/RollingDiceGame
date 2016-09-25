using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private Mob mob;
    private UIManager uiManager;
    private RaycastHit hit;
    private int health;
    private int damage;
    private int fullHealth;

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
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();       
        CreatePlayerStats(100, 15);
        fullHealth = this.Health;
        uiManager.PlayerHealthSlider(fullHealth,this.Health);
        
    }
    public void CreatePlayerStats(int health,int damage)
    {
        this.Health = health;
        this.Damage = damage;
    }
    public void GetDamage(int damage)
    {
        this.Health -= damage;
        uiManager.PlayerHealthSlider(fullHealth,this.Health);
        if (this.Health <= 0)
            gameManager.ChangeState(State.playerLoose);

    }
    public void Attack()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200))
            {
                if (hit.collider.CompareTag("Mob"))
                {
                    mob = hit.collider.gameObject.GetComponent<Mob>();
                    mob.GetDamage(Random.Range(3, this.Damage));
                    
                }
            }

        }
        //mob = GameObject.
    }
}
