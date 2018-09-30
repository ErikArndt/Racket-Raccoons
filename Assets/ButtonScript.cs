using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button m_Attract_Button;
    public enum ButtonState { Idle, Attract, Repel };
    public static ButtonState cbstate = ButtonState.Idle;
    // Use this for initialization
    void Start()
    {
        m_Attract_Button = GetComponent<Button>();
        m_Attract_Button.onClick.AddListener(CreateAttract);
    }

    void CreateAttract()
    {
        if (cbstate == ButtonState.Attract)
        {
            cbstate = ButtonState.Repel;
            Debug.Log("Repelling");
        }
        else
        {
            cbstate = ButtonState.Attract;
            Debug.Log("Attracting");
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
