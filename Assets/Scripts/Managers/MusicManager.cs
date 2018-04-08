using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	private static MusicManager instance;

	public List<AudioClip> musics;
	
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start ()
	{
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

	public static MusicManager GetI()
	{
		return instance;
	}

	public void SetMusic(int musicID)
	{
		audioSource.clip = musics[musicID];
		audioSource.Play();
	}
}
