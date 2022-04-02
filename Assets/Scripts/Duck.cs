using UnityEngine;
using UnityEngine.UI;
public class Duck : MonoBehaviour
{
    public bool launched = false;
    public GameObject jetpack;
    public GameObject helmet;
    public Rigidbody2D rb;
    public Cannon cannon;

    public int helmetLevel = 0;
    public float launchSpeed = 2500f;
    public bool jetpackUnlocked = false;

    public Text moneyText;
    public Text altText;

    private GameManager gm;
    private int maxAlt;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb.simulated = false;
        cannon = GetComponentInParent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + gm.money;
        if(!launched)
        {
            altText.text = "Altitude: 0M";
        }
        if(launched)
        {
            int oldAlt = (int)transform.position.y;
            altText.text = "Altitude: " + Mathf.RoundToInt(transform.position.y) + "M";
            maxAlt = oldAlt > maxAlt ? oldAlt : maxAlt;
        }
        if (launched && rb.velocity.y < -30)
        {
            gm.money += maxAlt;
            maxAlt = 0;
            launched = false;
            rb.simulated = false;
            rb.velocity = Vector2.zero;
            transform.parent = GameObject.Find("Cannon").transform;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = new Vector3(0.022f, 1.731f, 0);
        }
    }

    public void Launch()
    {
        if (!launched)
        {
            rb.simulated = true;
            this.transform.parent = null;
            Debug.Log("force added");
            rb.AddRelativeForce(transform.up * launchSpeed);
            launched = true;
        }
    }
}
