using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public SinkableFactory sinkableFactory;

    public void Start()
    {
        instance = this;
    }

    public static Sinkable GetSinkableByID(int id)
    {
        return instance.sinkableFactory.GetSinkableByID(id);
    }

}
