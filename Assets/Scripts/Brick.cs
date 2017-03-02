using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;						
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++; //compact version of timesHit = timesHit + 1;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount --; //-- is same as deincrementing breableCount by 1
			levelManager.brickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		}else {
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject puff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null){ //STATEMENT ENSURES A SPRITE IS LOADED TO AVOID ODD FAILURE
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else {
			Debug.LogError("Brick Sprite Missing");
		}
	}
}
