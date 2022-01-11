using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class GameManager : BaseGameManager
    {
        public UserStatsManager userManager;
        public BaseUserManager baseUserManager;
        //Singleton Pattern - cou can acces game manager from anywhere in the scripting by typing GameManager.instance
        public static GameManager instance { get; private set; }

        public GameManager()
        {
            instance = this;
        }

        private void Awake()
        {
            // ------------------------------------------------------
            // this code section isn't in the book, but it's provided to make
            // the game run without having to start it via the menu. It
            // is purely for test reasons. Basically, the game adds a player
            // to the BaseUserManager component in the menu. If you try to
            // run this scene from the core scene, that player hasn't been
            // added so the game would throw an error. We check here that
            // a player has been added and, if not, add one as needed
            if (baseUserManager == null)
                baseUserManager = GetComponent<BaseUserManager>();

            if (baseUserManager.GetPlayerList().Count < 1) // get the player list from baseusermanager component and check players are in it
            {
                // reset baseusermanager
                baseUserManager.ResetUsers();

                // add a new player to the game
                baseUserManager.AddNewPlayer();
            }
            // ------------------------------------------------------
        }

        public void Start()
        {
            Debug.Log("SetTargetGameState = " + targetGameState);

            SetTargetState(Game.State.loaded);
        }

        public override void UpdateTargetState()
        {
            Debug.Log("TargetGameState = " + targetGameState);
            if (targetGameState == currentGameState)
                return;

            switch (targetGameState)
            {
                case Game.State.idle:
                    break;

                case Game.State.loading:
                    SetTargetState(Game.State.loaded);
                    break;

                case Game.State.loaded:
                    Loaded();
                    break;

                case Game.State.gameStarting:
                    GameStarting();
                    StartGame();
                    SetTargetState(Game.State.gameStarted);
                    break;

                case Game.State.gameStarted:
                    GameStarted();
                    SetTargetState(Game.State.gamePlaying);
                    break;

                case Game.State.gamePlaying:
                    break;

                case Game.State.gameEnded:
                    EndGame();
                    GameEnded();
                    break;

                case Game.State.gamePausing:
                    break;

                case Game.State.gameUnPausing:
                    break;

                case Game.State.restarting:
                    break;
            }
            currentGameState = targetGameState;
        }

        public override void Loaded()
        {
            SetTargetState(Game.State.gameStarting);
        }
        private void StartGame()
        {

        }

        private void EndGame()
        {
            throw new NotImplementedException();
        }


    }
}
