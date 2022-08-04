using Godot;
using System;

namespace Fractural.CSharpEvents.EventLinkers {
	public class EventLinker1 : CSharpEventLinker
	{
		public override void _EnterTree()
		{
			GetNode<DummyScript>("../Dummy").IntegerActionEvent += GetNode<DummyScript>("../Dummy3").OnIntegerEvent;
		}
	}
}
