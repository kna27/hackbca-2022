using UnityEngine;

public class Duck : MonoBehaviour
{
    public bool launched = false;
    private GameObject jetpack;
    private GameObject helmet;
    private Rigidbody2D rb;
    private Cannon cannon;
    public float launchSpeed = 2500f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.simulated = false;
        cannon = GetComponentInParent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
