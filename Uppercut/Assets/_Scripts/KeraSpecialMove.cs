using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeraSpecialMove : MonoBehaviour
{
    public string specialString, searchString;
    GameObject countdownIMG;
    public GameObject model;
    Animator anim;
    PlayerMovement move;
    Countdown go;
    Slider meterSlider;
    public AudioClip hitClip, meterAttackClip;
    AudioSource source;
    public bool isPlayerOne;
    public Collider col;
    public GameObject teleportParticles;

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
                StartCoroutine(Teleport());
            }
        }
    }

    IEnumerator Teleport()
    {
        model.SetActive(false);
        move.enabled = false;
        Instantiate(teleportParticles, gameObject.transform.position, Quaternion.identity);

        if (isPlayerOne)
        {
            gameObject.transform.position -= new Vector3(3, 0, 0);
        }
        else
        {
            gameObject.transform.position += new Vector3(3, 0, 0);
        }
                
        yield return new WaitForSeconds(0.25f);

        model.SetActive(true);
        Instantiate(teleportParticles, gameObject.transform.position, Quaternion.identity);
        move.enabled = true;

    }
}
