using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float moveSpeed;
    public int stage;
    GameObject duck;
    AudioSource audSrc;

    // Start is called before the first frame update
    void Start()
    {
        audSrc = GetComponent<AudioSource>();
        moveSpeed = Random.Range(-5, 5);
        duck = GameObject.Find("Duck");
    }

    void Update()
    {
        transform.position = new Vector2(moveSpeed * Time.deltaTime, transform.position.y);
    }

    void OnHit()
    {
        if(stage <= duck.GetComponent<Duck>().helmetLevel)
        {
            Break();
        }
        else
        {
            duck.GetComponent<Rigidbody2D>().velocity = new Vector2(duck.GetComponent<Rigidbody2D>().velocity.x * (1 - stage * 0.25f), duck.GetComponent<Rigidbody2D>().velocity.y * (1 - stage * 0.25f));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.name == "Duck")
        {
            audSrc.Play();
            OnHit();
        }
    }

    void Break()
    {
        Destroy(this.gameObject);
    }
}
