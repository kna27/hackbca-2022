using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool moves;
    public float moveSpeed;
    public int stage;
    GameObject duck;
    AudioSource audSrc;

    // Start is called before the first frame update
    void Start()
    {
        audSrc = GetComponent<AudioSource>();
        moveSpeed = Random.Range(0.25f, 3);
        duck = GameObject.Find("Duck");
    }

    void Update()
    {
        if (moves)
        {
            transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
            if (transform.position.x > 20)
            {
                transform.position = new Vector2(-15, transform.position.y);
            }
        }
    }

    void OnHit()
    {
        Debug.Log(stage + ": " + duck.GetComponent<Duck>().helmetLevel);
        if(stage <= duck.GetComponent<Duck>().helmetLevel)
        {
            // wait until sfx is done playing before destroy
            Break();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.name == "Duck")
        {
            Debug.Log(stage + ": " + duck.GetComponent<Duck>().helmetLevel);
            if (stage <= duck.GetComponent<Duck>().helmetLevel)
            {
                Break();
            }
            Debug.Log("a");
            audSrc.Play();
            OnHit();
        }
    }

    void Break()
    {
        Destroy(this.gameObject);
    }
}
