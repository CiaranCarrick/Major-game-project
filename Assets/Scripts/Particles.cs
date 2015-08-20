using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
	public float xPos;// These will be used to contain values for each methods constructor
	public float yPos;//
	public float xScale;//
	public float yScale;//
	public float speed;//
	public Color color;//
	Vector3 Direction; //Direction of the particles

	public void SetupParticle(float _x, float _y, float _xScale, float _yScale, float _speed, Vector3 _dir, Color _col, float _lifespan) {
		xPos = _x;
		yPos = _y;
		xScale = _xScale;
		yScale = _yScale;
		speed = _speed;
		Direction = _dir;
		color= _col;

		Vector3 newPos = new Vector3(xPos, yPos,0);
		transform.position = newPos;
		Vector3 newScale = new Vector3(xScale, yScale, 0.1f);
		transform.localScale = newScale;
		GetComponent<Renderer>().material.color = _col;
		Invoke ("DestroyParticles", _lifespan);
	}
	
	
	void DestroyParticles(){// Remove particles
		Destroy(gameObject);
	}

	public void CreateParticles(Vector3 pos, Color _col, float _spd, int part_amount){// Location of particles, Color & Parts speed and amount
		for (int i = 0; i < part_amount; i++) {
			GameObject particle = GameObject.CreatePrimitive (PrimitiveType.Quad);
			particle.GetComponent<Renderer>().material.shader = Shader.Find ("Unlit/Color");// Removes light effect on Quad
			particle.name = "Particle";
			particle.AddComponent<Particles> ();
			Particles party = particle.GetComponent<Particles> ();
			Vector3 Direction = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0); //Random directions for particles
			party.SetupParticle (pos.x, pos.y, Random.Range (0.2f, 0.2f), Random.Range (0.2f, 0.2f), _spd, Direction, _col, 1);
		}
	}
	
	// Use this for initialization
	void Start(){
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Direction * speed);
	}
}
