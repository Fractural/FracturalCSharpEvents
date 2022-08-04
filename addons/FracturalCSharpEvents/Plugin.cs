using Godot;
using Fractural.Plugin;

#if TOOLS
namespace Fractural.CSharpEvents
{
	[Tool]
	public class Plugin : ExtendedPlugin
	{
		public CSharpEventsInspector EventsInspector { get; set; }
		public override string PluginName => "FracturalCSharpEvents";

		protected override void Load()
		{
			var inspectorWindowPrefab = ResourceLoader.Load<PackedScene>("res://addons/FracturalCSharpEvents/CSharpEventLinkerInspector.tscn");
			EventsInspector = inspectorWindowPrefab.Instance<CSharpEventsInspector>();
			EventsInspector.Init(this, AssetsRegistry);
			AddManagedControlToDock(EditorPlugin.DockSlot.RightBr, EventsInspector);
		}

		protected override void Unload()
		{
			DestroyManagedControl(EventsInspector);
		}
	}
}
#endif