using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    private int nextScene;
    public static int boardType;
    public SoundController soundController;
    public static bool loadGame = false;
    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void Standart()
    {
        MainCode game = new MainCode();
        boardType = 0;
        soundController.playSounds("buttonClick");
        SceneManager.LoadScene(nextScene);
        game.StartGame();
    }

    //diamond
    public void Cross()
    {
        MainCode game = new MainCode();
        soundController.playSounds("buttonClick");
        boardType = 2;
        SceneManager.LoadScene(nextScene);
        game.StartGame();
    }
    public void Plus()
    {
        MainCode game = new MainCode();
        soundController.playSounds("buttonClick");
        boardType = 3;
        SceneManager.LoadScene(nextScene);
        game.StartGame();
    }
    public void Arrow()
    {
        MainCode game = new MainCode();
        soundController.playSounds("buttonClick");
        boardType = 4;
        SceneManager.LoadScene(nextScene);
        game.StartGame();
    }
    public void Pyramid()
    {
        MainCode game = new MainCode();
        soundController.playSounds("buttonClick");
        boardType = 5;
        SceneManager.LoadScene(nextScene);
    }
    //diamond2
    public void Diamond()
    {
        MainCode game = new MainCode();
        soundController.playSounds("buttonClick");
        boardType = 6;
        SceneManager.LoadScene(nextScene);
        game.StartGame();
    }

    public void Load()
    {
        loadGame = true;
        //MainCode game = new MainCode();
        soundController.playSounds("buttonClick");
        SceneManager.LoadScene(nextScene);
        //game.LoadGameFromFile();
        Debug.Log("saved game is loaded");

    }
  
    public void Save()
    {
        soundController.playSounds("buttonClick");
        SceneManager.LoadScene(nextScene);
        Debug.Log("game is saved");
    }
}
