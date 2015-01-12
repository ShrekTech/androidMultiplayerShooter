using System;
using UnityEngine;
namespace Jetpack
{
	public interface IJetpackState
	{
		IJetpackState handleInput();
		void Update(MonoBehaviour jetpack);
	}
}

