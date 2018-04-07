using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public SinkableFactory sinkableFactory;
    public Player player;

    public void Start()
    {
        instance = this;
    }

    public static Sinkable GetSinkableByID(int id)
    {
        return instance.sinkableFactory.GetSinkableByID(id);
    }

    public static void SetPlayerSinkable(int sinkableID)
    {
        instance.player.sinkableID = sinkableID;
        instance.player.isTakeSinkable = true;
    }

}
