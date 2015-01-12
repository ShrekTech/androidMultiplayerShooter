using System;
using UnityEngine;
namespace Jetpack
{
	public interface IJetpackState
	{
		void InitialiseState();
		IJetpackState HandleInput(JetpackStateFactory jetpackStateFactory);
		void Update(MonoBehaviour jetpack);
	}
}

