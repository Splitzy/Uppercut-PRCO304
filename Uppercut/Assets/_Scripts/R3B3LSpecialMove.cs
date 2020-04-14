using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R3B3LSpecialMove : MonoBehaviour
{
    public string specialString, searchString;
    public GameObject projectile;
    public Transform spawn;
    GameObject countdownIMG;
    public GameObject model;
    Animator anim;
    PlayerMovement move;
    Countdown go;
    Slider meterSlider;
    public AudioClip hitClip, meterAttackClip;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        meterSlider = GameObject.Find(searchString).GetComponent<Slider>();
        countdownIMG = GameObject.Find("Countdown");
        anim = model.GetComponent<Animator>();
        move = gameObject.GetComponent<PlayerMovement>();
        go = countdownIMG.GetComponent<Countdown>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(go.canAttack)
        {
            if (Input.GetButtonDown(specialString) && meterSlider.value == 100)
            {
                GetComponent<PlayerAttack>().specialMeter = 0;
                Instantiate(projectile, spawn.position, spawn.rotation);
            }
        }
    }
}
