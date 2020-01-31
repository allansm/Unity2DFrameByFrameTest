using UnityEngine;
using System.Collections;

public class Enemy1Controller : MonoBehaviour {
	public Transform player;
	public float speed;
	public Animator ani;
	private Vector3 positionLeft;
	private Vector3 positionRight;
	private bool moving;
	private Collider2D target;
	public float currentHp = 100;
	void Start () {
		positionRight = transform.localScale;
		positionLeft = transform.localScale;
		positionLeft.x*= -1;
	}
	// Update is called once per frame
	void Update () {
		attack();
		follow();
		if(currentHp <= 0){
			Destroy(this.gameObject);
		}
	}
	void follow(){		
		moving = false;
		if(player.position.x-4 > transform.position.x){
			transform.Translate(speed*Time.deltaTime,0,0);
			ani.SetFloat("speed",speed);
			transform.localScale = positionRight;
			moving = true;
		}else if(player.position.x+5 < transform.position.x){
			transform.Translate(speed*-1*Time.deltaTime,0,0);
			ani.SetFloat("speed",speed);
			transform.localScale = positionLeft;
			moving = true;
		}
		if(player.position.y > transform.position.y){
			transform.Translate(0,speed*Time.deltaTime,0);
		}else if(player.position.y+1 < transform.position.y){
			transform.Translate(0,speed*-1*Time.deltaTime,0);
			ani.SetFloat("speed",speed);
			moving = true;
		}
		if(player.position.y > transform.position.y){
			transform.Translate(0,speed*Time.deltaTime,0);
			ani.SetFloat("speed",speed);
			moving = true;
		}
	}
	IEnumerator waitAnimation(){
       yield return new WaitForSeconds(0.5f);
	   target.gameObject.transform.root.Translate(transform.localScale.x*1,0,0);
	   yield return new WaitForSeconds(0.5f);
	   //Destroy(enemy.gameObject);
	}
	void attack(){
		if(target != null){
			transform.localScale = player.position.x > transform.position.x?positionRight:positionLeft;
			ani.SetFloat("speed",0);
			ani.SetTrigger("attack");
			StartCoroutine(waitAnimation());
			
		}
		
	}
	public void doDamage(){
		currentHp -= 34f;
	}
	void OnTriggerStay2D(Collider2D other){
        //Destroy(other.gameObject);
		if(other.gameObject.tag == "player"){
			target = other;
		}
    }
	void OnTriggerExit2D(Collider2D collision){
		target = null;
	}
}
