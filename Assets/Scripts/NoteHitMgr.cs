using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitMgr : MonoBehaviour
{
	NoteGenerator ng;
	Vector3 startPos;
	public AudioSource hitSoundManager;
	public AudioClip hitSound;

	private void Start()
	{
		ng = GameObject.Find("NoteGenerator").GetComponent<NoteGenerator>();
		startPos = ng.setStartPos(startPos);
		if(gameObject.name == "HitLine1")
		{
			transform.position = new Vector3(-6, startPos.y + 30, 0);
		}
		else if(gameObject.name == "HitLine2")
		{
			transform.position = new Vector3(6, startPos.y + 30, 0);
		}
		
		hitSoundManager = GetComponent<AudioSource>();

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{

		}
		if (Input.GetKeyDown(KeyCode.Comma))
		{

		}
	}

	public void PlayHitSound(AudioSource source, AudioClip sound)
	{
		source.Stop();
		source.clip = sound;
		source.loop = false;
		source.time = 0;
		source.Play();
	}
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.gameObject.name);
		//PlayHitSound(hitSoundManager, hitSound);
		Destroy(collision.gameObject);
	}

	// Update is called once per frame
}
