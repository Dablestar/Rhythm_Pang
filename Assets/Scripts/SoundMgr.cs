using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
	float offset;
	SMParser sm;
	bool songStart;
	bool songEnd;
	string songFilePath;

	public AudioClip mainMusic;
	public AudioSource musicPlayer;


    // Start is called before the first frame update
    void Start()
    {
		sm = GameObject.Find("NoteGenerator").GetComponent<SMParser>();
		offset = sm.meta.offset;

		songFilePath = sm.meta.musicPath;

		musicPlayer = GetComponent<AudioSource>();

		mainMusic = GetComponent<AudioClip>();

		musicPlayer.clip = mainMusic;

		musicPlayer.Play();

		StartCoroutine("OffsetCalc");


		
    }


	IEnumerator OffsetCalc()
	{
		yield return new WaitForSeconds(offset);
		yield return null;
	}


}
