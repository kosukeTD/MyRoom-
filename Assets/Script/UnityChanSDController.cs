using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanSDController : MonoBehaviour {

	private Animator myAnimator;
	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {

		this.myAnimator = GetComponent<Animator> ();
		this.myAnimator.SetFloat ("Speed", 1);
		this.myRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
