using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button m_Attract_Button;
    public SpriteRenderer bg;
    public Sprite repel, attract;

    public AudioClip musAtt, musRep;
    public AudioSource asrc;
    public enum ButtonState { Idle, Attract, Repel };
    public static ButtonState cbstate = ButtonState.Idle;
    // Use this for initialization
    void Start()
    {
        if (cbstate == ButtonState.Repel)
        {
            bg.sprite = repel;
            asrc.Stop();
            asrc.PlayOneShot(musRep, 0.6f);
        }
        else
        {
            bg.sprite = attract;
            asrc.Stop();
            asrc.PlayOneShot(musAtt);
        }

        m_Attract_Button = GetComponent<Button>();
        m_Attract_Button.onClick.AddListener(CreateAttract);
    }
    
    void CreateAttract()
    {
        if (cbstate == ButtonState.Repel)
        {
            cbstate = ButtonState.Attract;
            Debug.Log("Attracting");
            bg.sprite = attract;
            asrc.Stop();
            asrc.PlayOneShot(musAtt);
        }
        else 
        {
            cbstate = ButtonState.Repel;
            Debug.Log("Repelling");
            bg.sprite = repel;
            asrc.Stop();
            asrc.PlayOneShot(musRep, 0.6f);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
