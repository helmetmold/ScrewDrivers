using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlowUp : MonoBehaviour
{

    public bool PinPulled = false;

    private bool explosionDone = false;

    bool outlined = true;

    public GameObject Text;

    public GameObject ExplosionPrefab;

    public GameObject explodehere;

    public AudioSource fuse;

    public AudioSource lighter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float timeremaining = 5;

    // Update is called once per frame
    void Update()
    {
        if(PinPulled)
        {
            fuse.Play();
            lighter.Play();
            transform.gameObject.tag = "Grenade";
            if (outlined)
            {
                this.GetComponent<Outline>().enabled = true;
                outlined = false;
            }

            Text.GetComponent<TextMeshPro>().enabled = true;
            if(timeremaining > 0)
            {
                timeremaining -= Time.deltaTime;
                DisplayTime(timeremaining);
            }
            else
            {
                this.GetComponent<Outline>().enabled = false;
                Text.GetComponent<TextMeshPro>().enabled = false;

                if(!explosionDone)
                {
                    Instantiate(ExplosionPrefab, explodehere.transform.position, explodehere.transform.rotation);
                    explosionDone = true;
                }

                GetComponent<ExplodeGrenade>().explode();

                Destroy(this);
            }



        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        Text.GetComponent<TextMeshPro>().text = seconds.ToString();
    }
}
