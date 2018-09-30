using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public RectTransform bar;
    public float power, charge, decay;
    private Rigidbody thisRb;
    private float chargeStart;
    enum ChargeState { Stable, Charging, Launched };
    private ChargeState cs = ChargeState.Stable;
    public static bool GoalReached = false;


// Use this for initialization

    void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        Debug.Log("Start");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GoalReached = true;
            Debug.Log("Collided");
            thisRb.isKinematic = true;
        }
    }

    IEnumerator DeathAnim()
    {
        while (transform.localScale.x > 0.05f)
        {
            transform.localScale *= decay;
            yield return null;
        }
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (cs == ChargeState.Stable) {
            transform.rotation = Quaternion.LookRotation(
                Vector3.forward, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                cs = ChargeState.Charging;
                chargeStart = Time.time;
            }
        } else if (cs == ChargeState.Charging) {
            Vector2 barScale = bar.sizeDelta;
            barScale.x += charge;
            bar.sizeDelta = barScale;

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                thisRb.AddForce(power*transform.up * (Time.time - chargeStart));
                cs = ChargeState.Launched;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }


        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine("DeathAnim");
        }

    }
}