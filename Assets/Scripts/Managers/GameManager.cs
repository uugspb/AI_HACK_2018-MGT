using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public SinkableFactory sinkableFactory;
    public Player player;

    public void Start()
    {
        instance = this;
        Debug.Log(instance);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public static Sinkable GetSinkableByID(int id)
    {
        return instance.sinkableFactory.GetSinkableByID(id);
    }

    public static void SetPlayerSinkable(int sinkableID)
    {
        Debug.Log("SetPlayerSinkable");
        instance.player.sinkableID = sinkableID;
        instance.player.isTakeSinkable = true;
    }

}
