using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public RectTransform bar;
    public float power, charge;
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
    // Update is called once per frame
    void Update()
    {
        if (cs == ChargeState.Stable) {
            transform.rotation = Quaternion.LookRotation(
                Vector3.forward, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

            if (Input.GetMouseButtonDown(0))
            {
                cs = ChargeState.Charging;
                chargeStart = Time.time;
            }
        } else if (cs == ChargeState.Charging) {
            Vector2 barScale = bar.sizeDelta;
            barScale.x += charge;
            bar.sizeDelta = barScale;

            if (Input.GetMouseButtonUp(0))
            {
                thisRb.AddForce(power*transform.up * (Time.time - chargeStart));
                cs = ChargeState.Launched;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

    }
}