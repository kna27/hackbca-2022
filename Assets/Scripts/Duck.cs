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
    public int maxAlt;

    public int altLvl1 = 0;
    public int altLvl2 = 200;
    public int altLvl3 = 500;
    public int space = 650;
    public int currentAltLvl = 0;
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
        if (!launched)
        {
            altText.text = "Altitude: 0M";
        }
        if (launched)
        {
            int oldAlt = (int)transform.position.y;
            altText.text = "Altitude: " + Mathf.RoundToInt(transform.position.y) + "M";
            if (oldAlt >= altLvl2)
            {
                if (oldAlt >= altLvl3)
                {
                    if (oldAlt >= space)
                    {
                        currentAltLvl = 3;
                    }
                    else
                    {
                        currentAltLvl = 2;
                    }
                }
                else
                {
                    currentAltLvl = 1;
                }
            }
            else
            {
                currentAltLvl = 0;
            }
            maxAlt = oldAlt > maxAlt ? oldAlt : maxAlt;
        }
        if (launched && (rb.velocity.y < -30 || transform.position.y < 0.1f))
        {
            gm.money += maxAlt;
            maxAlt = 0;
            launched = false;
            rb.simulated = false;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
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
            transform.parent = null;
            rb.AddRelativeForce(transform.up * launchSpeed);
            launched = true;
        }
    }
}
