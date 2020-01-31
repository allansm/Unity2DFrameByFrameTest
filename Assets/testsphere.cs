using UnityEngine;
using System.Collections;

public class testsphere : MonoBehaviour {
	public Transform player;
	private int variation = 1;
	public float speed;
	public Animator ani;
	public bool dead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		deadSphere();
		follow();
	}
	void deadSphere(){
		if(player == null){
			Destroy(this.gameObject);
		}
	}
	void follow(){
		if(!dead){
			variation *=-1;
			if(player.position.x-4 > transform.position.x){
				transform.Translate(speed*Time.deltaTime,0,0);
			}else if(player.position.x+4 < transform.position.x){
				transform.Translate(speed*-1*Time.deltaTime,0,0);
			}
			if(player.position.y -4> transform.position.y){
				transform.Translate(0,speed*Time.deltaTime,0);
			}else if(player.position.y+4 < transform.position.y){
				transform.Translate(0,speed*-1*Time.deltaTime,0);
			}
			if(player.position.y+4 > transform.position.y){
				transform.Translate(0,speed*Time.deltaTime,0);
			}
		}
		if(Input.GetKey("x") && dead){
			dead = false;
			ani.SetBool("dead",dead);
		}
		else if(Input.GetKey("x") && !dead){
			dead = true;
			ani.SetBool("dead",dead);
		}
	}
}
