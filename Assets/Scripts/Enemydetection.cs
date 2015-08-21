using UnityEngine;
using System.Collections;

public class Enemydetection : MonoBehaviour{
	AudioSource hitsound; 
	AudioClip hitclip;
	public GameObject Player;
	public Transform sightstart, sightend;
	public float fov;
	Interaction interaction;
	bool spotted;
	Color color, MyColour;
	public static int PlayerDeaths;
	[Range(0,180f)]
	Particles bam;
	// Use this for initialization
	void Start () {
		bam = gameObject.AddComponent<Particles> ();//Add Particles script instance to
		MyColour = this.sightstart.GetComponent<Light> ().color;
		hitsound = gameObject.AddComponent<AudioSource> ();//
		hitclip = (AudioClip)Resources.Load ("Sounds/Hit_Hurt22");// Loading the tracks from Resources
		hitsound.clip = hitclip; //Assigning the hit clip to the AudioSource Component
		Player = GameObject.Find ("Player");
		interaction = Player.GetComponent<Interaction> ();
		fov = sightstart.GetComponent<Light> ().spotAngle;
		hitsound.volume = 1f;
	}
	
	void EnemyDetection() {
		if (UI.debugmode == false) {
			Vector2 Distance = Player.transform.position - transform.position;
			Distance.Normalize (); //makes the vector of length 1 (x, y, z componenet of vector each divided by the length or magnitude of the vector
			//magnitude is caculated as the square root of x2, y2, z2, e.g(4, 3, 0) = 16 + 9 + 0 = 25. Squ root of 25 is 5, which is the length or magnitude of the vector
			//Debug.DrawLine (transform.position, Player.transform.position);
			//Debug.DrawLine (transform.position, sightend.transform.position);
			float dot = Vector2.Dot (Distance, sightend.transform.TransformDirection (Vector2.up)); //takes two vectors and returns the dot product between them
			// instead of dot and float angle could do, float angle = Vector3.Angle(Distance, Direction);
			float angle = Mathf.Acos (dot) * Mathf.Rad2Deg; //passes DOT through Acos, which returns the angle of DOT in radians.* by Rad2Deg to convert it to degrees.
			//Debug.Log ( angle);
			float distance = (Player.transform.position - transform.position).magnitude;//creates a float which stores position between A & B
			//Debug.Log (distance);
			float Sightdistance = (this.sightend.transform.position - this.sightstart.transform.position).magnitude;//creates a float which stores position between A & B
			sightstart.GetComponent<Light> ().range = Sightdistance; //Set light range equal to that of sightends position

			if (distance <= Sightdistance && angle < fov * 0.5f) { 
				//Debug.DrawLine (sightstart.position, Player.transform.position, Color.blue);
				RaycastHit2D middlehit = Physics2D.Linecast (sightstart.position, sightend.position, 1 << 8 | 1 << 10); //8 Player layer|10 Wall layer
				RaycastHit2D hit = Physics2D.Linecast (sightstart.position, Player.transform.position, 1 << 8 | 1 << 10); //8 Player layer|10 Wall layer

				if (middlehit) {
					if (middlehit.transform.gameObject == Player) {
						bam.CreateParticles (Player.transform.position, new Color(254f/255f, 87f/255f, 69f/255f,1), 0.2f, 20);
						spotted = true;
						Spotted ();
						return;
					}//end Nest if
				}
				if (hit) {
					if (hit.transform.gameObject == Player) {
						bam.CreateParticles (Player.transform.position, new Color(254f/255f, 87f/255f, 69f/255f,1), 0.2f, 20);
						spotted = true;
						Spotted ();
						return;
					}//end Nest if
				}//end if
			}//end angle
	
		}//end Raycast
	}//end if statement
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (UI.debugmode == false) {
			if (coll.gameObject.name == "Player") {
				Spotted ();
			}
		}//end if statement
	}
	void Spotted(){
		if (spotted == true) {
			sightstart.GetComponent<Light>().color = Color.red;
		}
		hitsound.Play();
		Player.SetActive(false);
		PlayerDeaths++;
		Invoke("Reset", 1f);
		interaction.Reset ();

	}
	void Reset(){
		sightstart.GetComponent<Light>().color=MyColour;
		spotted = false;
		Player.SetActive (true);
		interaction.Reset ();
	}



//	void behaviour(){
//
//	}
	// Update is called once per frame
	void Update () {
		EnemyDetection ();
//		behaviour ();
	}
}
