using System;
using UnityEngine;
namespace Jetpack
{
	public interface IJetpackState
	{
		void initialiseState();
		IJetpackState HandleInput();
		void Update(MonoBehaviour jetpack);
	}
}

