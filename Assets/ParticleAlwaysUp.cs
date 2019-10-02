using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAlwaysUp : MonoBehaviour
{
    public GameObject particle;

	void Update ()
    {
        particle.transform.rotation = Quaternion.Euler(-90, 0, 0);
	}
}
