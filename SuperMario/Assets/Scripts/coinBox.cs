﻿using UnityEngine;
using System.Collections;

public class coinBox : boxBehaviour {



	public void Hit() {
		Spawner (gameObject.tag);

	}
}
