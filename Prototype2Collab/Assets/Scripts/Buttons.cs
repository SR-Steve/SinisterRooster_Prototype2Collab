using UnityEngine;
using System.Collections;

namespace Branden
{
    public class Buttons : MonoBehaviour
    {
        public GameObject anais;
        public GameObject Button_Up;
        public GameObject drapWall;

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
            if (other.gameObject.tag == "Player")
            {
                Button_Up.gameObject.GetComponent<SpriteRenderer>().sprite = Button_Pres;
                drapWall.SendMessage("MoveDown");
            }
        }
    }
}
