using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float Move_1;
	public float Move_2;




	// Use this for initialization
	void Start () {
		//PontoOriginal = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {


		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= Move_1)
        {

			Debug.Log ("hhhh");
			x = Move_2;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
