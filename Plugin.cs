using Godot;
using Fractural.Plugin;

#if TOOLS
namespace Fractural.CSharpEvents
{
	[Tool]
	public class Plugin : ExtendedPlugin
	{
		public CSharpEventsInspector EventsInspector { get; set; }

		public override void _EnterTree()
		{
			base._EnterTree();

			var inspectorWindowPrefab = ResourceLoader.Load<PackedScene>("res://addons/FracturalCSharpEvents/CSharpEventLinkerInspector.tscn");
			EventsInspector = inspectorWindowPrefab.Instance<CSharpEventsInspector>();
			EventsInspector.Init(this, AssetsRegistry);
			AddManagedControlToDock(EditorPlugin.DockSlot.RightBr, EventsInspector);
			GD.PushWarning("Loaded FracturalCSharpEvents");
		}

		public override void _ExitTree()
		{
			DestroyManagedControl(EventsInspector);
		}
	}
}
#endif