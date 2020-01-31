using UnityEngine;
using System.Collections;

public class character1test : MonoBehaviour {
	private float x;
	private float y;
	public float velocity;
	public Animator ani;
	private Vector3 positionLeft;
	private Vector3 positionRight;
	private bool transformation = false;
	public Collider2D enemy;
	void Start () {
		positionRight = transform.localScale;
		positionLeft = transform.localScale;
		positionLeft.x*= -1;
	}
	void Update () {
		move();
		attack(enemy);
		changeForm();
	}
	void move(){
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
		if(x != 0 || y !=0){
			x = x*Time.deltaTime*velocity;
			y = y*Time.deltaTime*velocity;
			if(x > 0){
				transform.localScale = positionRight;
			}else if(x < 0){
				transform.localScale = positionLeft;
			}
			transform.Translate(x,y,0);
			ani.SetBool("running",true);
		}else{
			ani.SetBool("running",false);
		}
		
	}
	IEnumerator waitAnimation(){
       yield return new WaitForSeconds(0.5f);
	   enemy.gameObject.transform.root.GetComponent<Enemy1Controller>().doDamage();
	   enemy.gameObject.transform.root.Translate(transform.localScale.x*2,0,0);
	   yield return new WaitForSeconds(0.5f);
	   //Destroy(enemy.gameObject);
	}
	void attack(Collider2D other){
		if(Input.GetKeyDown("j") && transformation){
			ani.SetTrigger("attack");
			if(enemy != null){
				//Destroy(enemy.gameObject);
				StartCoroutine(waitAnimation());
			}
		}
	}
	void changeForm(){
		if(Input.GetKeyDown("c")){
			transformation = transformation == true?false:true;
			ani.SetBool("transform",transformation);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "enemy"){
			enemy = other;
		}
    }
	void OnTriggerExit2D(Collider2D collision){
		enemy = null;
	}
	
}
