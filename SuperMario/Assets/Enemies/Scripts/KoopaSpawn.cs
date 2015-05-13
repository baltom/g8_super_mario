using UnityEngine;
using System.Collections;

public class KoopaSpawn : MonoBehaviour {

    private Object Koompa;

    // Use this for initialization
    void Start() {
        Koompa = UnityEditor.AssetDatabase.LoadMainAssetAtPath("Assets/Enemies/KoopaTroopa.prefab");
    }

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(transform.position, Camera.main.transform.position) < Camera.main.orthographicSize * 2) {
            Instantiate(Koompa, transform.position, Quaternion.identity);
            GameObject.Destroy(this);
        }
    }
}
