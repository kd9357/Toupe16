using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class AudioPlay : MonoBehaviour {
    public AudioSource Shout0;
    public AudioSource Shout1;
    public AudioSource Shout2;
    public AudioSource WaveShout0;
    public AudioSource WaveShout1;
    public AudioSource WaveShout2;

    //May add more audio sources for random effect
    private int i;

    public Sprite idleSprite;
    public Sprite shoutSprite;
    private SpriteRenderer spriteRenderer;

    public string Attack;
    public string waveAttack;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = idleSprite;
	}
	
	// Update is called once per frame
	void Update () {
		bool fire = CrossPlatformInputManager.GetButtonDown(Attack);
        bool waveFire = CrossPlatformInputManager.GetButtonDown(waveAttack);
        if (fire)
        {
            int old_i = i;
            while(i == old_i)
                i = Random.Range(0, 3);
            Shout0.Stop();
            Shout1.Stop();
            Shout2.Stop();
            if (i == 0)
                Shout0.Play();
            else if (i == 1)
                Shout1.Play();
            else
                Shout2.Play();
        }
        else if(waveFire)
        {

        }
        if (Shout0.isPlaying || Shout1.isPlaying || Shout2.isPlaying)
            spriteRenderer.sprite = shoutSprite;
        else
            spriteRenderer.sprite = idleSprite;
    }
}
