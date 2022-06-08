using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace CloudFine.ThrowLab.Oculus
{
    public class TutorialScript : MonoBehaviour
    {
        private TextMeshPro TextTutorial;

        public int slide = 0;

        public GameObject rect;

        public GameObject Spawner;

        public GameObject TextinSky;

        private string[] ToDisplay = new string[]
        { "Welcome to Screw Drivers!\n\nPress Green Button to go to continue",
      "Protect the bridge from the oncoming vehicles!\n\nFirst lets throw bricks!\nUse the Controllers to grab a brick and release while throwing",
      "Nice! Now for the grenade!\n\ngrab the grenade with one hand, and pull out the pin with the other hand\n\nYou have five seconds to throw the grenade\n\nThe explosion radius of the grenade is approximetely two lanes wide",
      "Good stuff! Finally let's use the bazooka\n\ngrab the bazooka with one hand, and put the rocket inside the barrel from the top\n\nPress the top trigger to fire",
      "Now your ready to play!\n\nDifferent Weapons will be introduced as the game continues\n\nYou will be able to see what wave you are on and how many lives you have by looking in the sky above the street",
      "Practice hitting Vehicles\n\nwhen you are ready press the blue button to start"
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
            if (slide == 1)
            {
                Spawner.GetComponent<LabManager>()._weapontospawn = LabManager.WeapontoSpawn.Brick;
            }
            if (slide == 2)
            {
                Spawner.GetComponent<LabManager>()._weapontospawn = LabManager.WeapontoSpawn.Grenade;
            }
            if (slide == 3)
            {
                Spawner.GetComponent<LabManager>()._weapontospawn = LabManager.WeapontoSpawn.Bazooka;
            }
            if (slide == 4)
            {
                TextinSky.gameObject.SetActive(true);
            }
            if (slide > 5)
            {
                rect.gameObject.SetActive(false);
            }
            TextTutorial.text = ToDisplay[slide];
        }
    }

}
