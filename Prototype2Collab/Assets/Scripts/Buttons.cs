using UnityEngine;
using System.Collections;

namespace Branden //Created by me, Branden
{
    public class Buttons : MonoBehaviour
    {
        /* Calling all neccessary game objects. -Branden */
        public GameObject anais;
        public GameObject Button_Up;
        public GameObject drapWall;

        /* This is for changing the sprite. -Branden */ 
        SpriteRenderer spr;
        public Sprite Button_Unp;
        public Sprite Button_Pres;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player") //If the player hits the trigger... -Branden
            {
                Button_Up.gameObject.GetComponent<SpriteRenderer>().sprite = Button_Pres; //Change the sprite... -Branden
                drapWall.SendMessage("MoveDown"); //And send a message to the drapwall function. -Branden
            }
        }
    }
}
