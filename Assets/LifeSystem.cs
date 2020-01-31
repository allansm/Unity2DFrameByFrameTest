using UnityEngine;
using System.Collections;

public class LifeSystem : MonoBehaviour {
	protected float maxHp = 100;
	protected float currentHp = 100;
	
	protected void reduceHp(float val){
		this.currentHp-=val;
	}
	protected void increaceHp(float val){
		this.currentHp+=val;
	}
}
