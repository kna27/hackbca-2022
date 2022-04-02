using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int stage;
    GameObject duck;
    public enum PowerupType
    {
        Coin,
        Pepper
    }
    public PowerupType powerupType; 
    // Start is called before the first frame update
    void Start()
    {
        duck = GameObject.Find("Duck");
    }

    void Update()
    {   
    }

    void OnHit()
    {
        if (powerupType == PowerupType.Coin)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().money += 25;
        }
        else
        {
            duck.GetComponent<Rigidbody2D>().velocity = new Vector2(duck.GetComponent<Rigidbody2D>().velocity.x * (1.25f), duck.GetComponent<Rigidbody2D>().velocity.y * (1.25f));
        }
        Break();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.name == "Duck")
        {
            OnHit();
        }
    }

    void Break()
    {
        Destroy(this.gameObject);
    }
}
