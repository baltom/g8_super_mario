using UnityEngine;
using System.Collections;

public class hiddenBox : boxBehaviour {
	
	public void Hit() {
		Spawner (gameObject.tag);
	}
}
