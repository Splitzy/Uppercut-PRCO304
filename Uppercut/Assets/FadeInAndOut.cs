using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAndOut : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    void FadeOutEnd()
    {
        this.gameObject.SetActive(false);
    }

    void FadeInEnd()
    {
        this.gameObject.SetActive(false);
        gameManager.GetComponent<Rounds>().StartRound();
    }
}
