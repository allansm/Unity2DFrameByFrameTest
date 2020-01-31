using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform player;
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.position.x+20 > transform.position.y || player.position.x-20 < transform.position.y){
			if(player.position.x-20 > transform.position.x){
				transform.Translate(speed*Time.deltaTime,0,0);
			}else if(player.position.x+20 < transform.position.x){
				transform.Translate(speed*-1*Time.deltaTime,0,0);
			}
		}
		if(player.position.y+10 > transform.position.y || player.position.y-10 < transform.position.y){
			if(player.position.y-10 > transform.position.y){
				transform.Translate(0,speed*Time.deltaTime,0);
			}else if(player.position.y+10 < transform.position.y){
				transform.Translate(0,speed*-1*Time.deltaTime,0);
			}
		}
		//if(player.position.y > transform.position.y+20){
			//transform.Translate(0,speed*Time.deltaTime,0);
		//}
	}
}
