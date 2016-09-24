using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Population : MonoBehaviour {
	public int Number = 100;
	public float Analphabetism = 0.9f;
	public float Hygiene = 0.1f;
	public Dictionary<string, float> Religions = new Dictionary<string, float>();
	public Dictionary<string, float> Cultures = new Dictionary<string, float>();
	//TODO: class Statistic working like a Dictionary<string, float> which values add up to 1.0f (100%)

	public void Start(){
		StartCoroutine ("Grow");
		Religions.Add ("Hinduism", 1.0f);
		Cultures.Add ("Hindu", 1.0f);
	}

	public IEnumerator Grow(){
		while (true) {
			Number += Number / 20;
			yield return new WaitForSeconds(60);
		}
	}
}
