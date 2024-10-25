using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer_Mario.Entities.Player;

public enum AnimationState
{
	Idle,
	Run_Right,
	Run_Left,
	Jump,
	Fall,
	Dead,
	Attack
}
