using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UiManager : MonoBehaviour
    {
        

        public Text idText;
        public Text nameText;
        public Text scoreText;
        public Text healthText;
        public Text hungerText;

        public Text stateText;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            idText.text = "Id : 0";
            nameText.text = "Name :" + GameManager.instance.userManager.GetName();
            scoreText.text = "Score :" + GameManager.instance.userManager.GetScore();
            healthText.text = "Health :" + GameManager.instance.userManager.GetHealth();
            hungerText.text = "Hunger :" + GameManager.instance.userManager.GetHunger();

            stateText.text = "State is :" + GameManager.instance.currentGameState.ToString();
        }
    }
}
