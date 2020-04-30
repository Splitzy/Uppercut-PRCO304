using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RykerSpecialMove : MonoBehaviour
{
    public string specialString, searchString;
    public Collider specialHitbox;
    GameObject countdownIMG;
    public GameObject model;
    Animator anim;
    bool attacking;
    PlayerMovement move;
    Countdown go;
    Slider meterSlider;
    public AudioClip meterAttackClip;
    public AudioClip[] hitClips;
    public GameObject trail;
    public GameObject hitParticles;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        meterSlider = GameObject.Find(searchString).GetComponent<Slider>();
        countdownIMG = GameObject.Find("Countdown");
        anim = model.GetComponent<Animator>();
        attacking = false;
        move = gameObject.GetComponent<PlayerMovement>();
        go = countdownIMG.GetComponent<Countdown>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (go.canAttack)
        {
            if (Input.GetButtonDown(specialString) && attacking == false && meterSlider.value == 100)
            {
                GetComponent<PlayerAttack>().specialMeter = 0;
                move.enabled = false;
                attacking = true;
                anim.SetTrigger("Kick");
                StartCoroutine(SpecialAttack(specialHitbox, 30f, 0.5f, 3.5f));
                trail.SetActive(true);
            }
        }
    }

    IEnumerator SpecialAttack(Collider col, float dmg, float wait, float force)
    {
        source.clip = meterAttackClip;
        source.Play();

        yield return new WaitForSeconds(wait);

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));

        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            {
                continue;
            }

            source.clip = hitClips[Random.Range(0, hitClips.Length)];
            source.Play();

            c.SendMessage("TakeDamage", dmg);

            if (c.gameObject.tag == "Player")
            {
                Vector3 dir = c.transform.position - transform.position;
                StartCoroutine(c.gameObject.GetComponent<PlayerHealth>().KnockBack(dir, force));
            }

            Instantiate(hitParticles, trail.transform.position, Quaternion.identity);

            GetComponent<PlayerAttack>().specialMeter += 10;
            meterSlider.value = GetComponent<PlayerAttack>().specialMeter;
        }

        yield return new WaitForSeconds(wait);

        attacking = false;
        move.enabled = true;
        trail.SetActive(false);
    }
}
