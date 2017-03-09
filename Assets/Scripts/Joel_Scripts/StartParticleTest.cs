using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticleTest : MonoBehaviour {

    public void PlayPartEff()
    {
        var lvl = GetComponent<ParticleSystem>();
        lvl.Play();
    }

}
