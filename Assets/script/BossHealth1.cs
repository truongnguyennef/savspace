using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth1 : MonoBehaviour
{
	// Start is called before the first frame update
	// Start is called before the first frame update
	Vector3 localScale;

	// Use this for initialization
	void Start()
	{
		localScale = transform.localScale;
	}

	// Update is called once per frame
	void Update()
	{
		localScale.x = Boss.health;
		transform.localScale = localScale;
	}
}
