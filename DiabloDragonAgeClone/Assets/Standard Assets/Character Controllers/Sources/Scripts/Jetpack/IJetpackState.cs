using System;
using UnityEngine;
namespace Jetpack
{
	public interface IJetpackState
	{
		IJetpackState HandleInput();
		void Update(MonoBehaviour jetpack);
	}
}

