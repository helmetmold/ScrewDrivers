using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    private TextMeshPro TextTutorial;

    public int slide = 0;

    public GameObject rect;

    private string[] ToDisplay = new string[] 
    { "Welcome to Screw Drivers!\nPress Green Button to go to continue",
      "Protect the bridge from the oncoming vehicles!\nFirst lets throw bricks!\nUse the Trigger to grab a brick and release while throwing",
      "Nice! Now for the grenade!\ngrab the grenade with one hand, and pull out the pin with the other hand\nYou have five seconds to throw the grenade\nThe explosion radius of the grenade is approximetely two lanes wide",
      "Good stuff! Finally let's use the bazooka\ngrab the bazooka with one hand, and put the rocket inside the barrel from the top\nPress the top trigger to fire",
      "Now your ready to play!\nDifferent Weapons will be introduced as the game continues\nYou will be able to see what wave you are on and how many lives you have by looking in the sky above the street",
      "Practice hitting Vehicles\nwhen you are ready press the blue button to start"
    };


    // Start is called before the first frame update
    void Start()
    {
        TextTutorial = GetComponent<TextMeshPro>();
    }

    public void IncreaseSlide()
    {
        slide++;
    }


    // Update is called once per frame
    void Update()
    {
        if(slide > 5)
        {
            rect.GetComponent<MeshRenderer>().enabled = false;
        }
        TextTutorial.text = ToDisplay[slide];
    }
}
