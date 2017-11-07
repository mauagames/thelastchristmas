using UnityEngine;
using System.Collections;

public class MusicLooper : MonoBehaviour
{
	/* To use this class, you'll need to have 2 sound sources */
	
	private AudioSource source;
	private AudioSource sourceRage;
	private float loopLenght;

	public AudioClip sound;
	public AudioClip soundRage;

	public float percent = 1.0f; //set to 0 to start a level with the rage music
	public float fullSongTime = 0.0f; //how long the intro + loop will last (seconds)
	public float loopStart = 0.0f; // how long takes the intro (seconds)


	void Awake()
	{
		var aSources = GetComponents<AudioSource>();
		source = aSources[0];
		sourceRage = aSources[1];

		loopLenght = fullSongTime - loopStart;
	}
	void Start()
	{
		source.clip = sound;
		sourceRage.clip = soundRage;

		source.Play();
		sourceRage.Play();
		InvokeRepeating("PlayLoop", fullSongTime, loopLenght);
	}
	void PlayLoop()
	{
		source.clip = sound;
		source.time = loopStart;
		source.Play();

		sourceRage.clip = soundRage;
		sourceRage.time = loopStart;
		sourceRage.Play();
	}
	void Update()
	{
		/* Used for adjusting volume manually in-editor */
		source.volume = percent;
		sourceRage.volume = 1.0f - percent;
	}
	
	/* Call this method from your rage controller to change intensity */
	void ChangeRageIntensity( float percentage ) //receives values from 0.0 to 1.0
	{
		source.volume = percentage;
		sourceRage.volume = 1.0f - percentage; 
	}
		
}
