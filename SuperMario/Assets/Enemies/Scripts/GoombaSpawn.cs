using UnityEngine;
using System.Collections;

public class GoombaSpawn : MonoBehaviour {

    public Object Goomba;

	// Use this for initialization
	void Start () {
        //Goomba = UnityEditor.AssetDatabase.LoadMainAssetAtPath("Assets/Enemies/Goomba.prefab");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Vector2.Distance(transform.position, Camera.main.transform.position) < Camera.main.orthographicSize*2) {
            Instantiate(Goomba, transform.position, Quaternion.identity);
            GameObject.Destroy(this);
        }
	}
}
