# Fractural CSharp Events 🌃

![Deploy](https://github.com/Fractural/FracturalCSharpEvents/actions/workflows/deploy.yml/badge.svg) ![Unit Tests](https://github.com/Fractural/FracturalCSharpEvents/actions/workflows/tests.yml/badge.svg)

This plugin creates an inspector window that allows you to link C# events in the Godot editor.

This inspector is compatible with any C# event, including `Action` and `EventHandler` events.

### Documentation

**Refresh Button** - Refreshes the events inspector to the current state of the scene. 

- The events inspector auto refreshes when:
    - a new scene is loaded.
    - a new node is selected and the `Follow Selected Button` is toggled on.
    - the resolution is rebuilt.
- You will have to manually press the **Refresh Button** if you delete, rename, or add a new node to the scene.  

**Follow Selected Button** - When toggled on, the events inspector will show only the currently selected node.

- When toggled, the events inspector will refresh automatically when you change your selected node.
- This simulates the behavior of the "Node" window that's built into Godot, as the "Node" window only shows the signals emitted by the currently selected node.

**Filter Nodes Search Bar** - Lets you filter the displayed nodes by their names.

**Filter Events Search Bar** - Lets you filter the displayed events by their names

**Create Event Linker Button** - Appears when no event linker is found. When pressed, it will create a node named "EventLinker" at the bottom of the scene.

- Event linker nodes have a `EventLinkerXX.cs` script created for them, where `XX` represents the next available number.
- All event linker scripts can be found under `res:\\addons\FracturalCommons\InspectorCSharpEvents\EventLinkers\`

### Use

#### Adding Event Listener
1. Open a scene
2. Press the **Create Event Linker Button** to create an event linker for that scene.
3. Find an event on the node you want.
4. Click on the `+` button on the right of the event to add a new event listener.
5. Click on the first `Empty` slot to assign the listener's node.
6. Click on the second `Empty` slot to assign the method on the listener's node.
    
    - The method select window will only show methods that are compatible with the event.

**Ex.**

![CSharp events inspector in action.](readme-assets/fractural_commons_csharp_events_inspector.gif)

#### Deleting Event Listener

1. Find an event on the node you want.
2. Press the `trash can` button on the left of the listener to delete it.

**Ex.**

![Event deletion demonstration.](readme-assets/fractural_commons_csharp_events_inspector_deletion.gif)

### Notes

This plugin procedurally generates C# code that links events to listeners. The linked C# events are stored in a node named "EventLinker" at the bottom of the scene's tree.

The events are linked during `_EnterTree()`, therefore "EventLinker' must always be placed at the bottom of the scene to ensure all the nodes have entered the tree when it links up the events. This behavior lets the event linking finish before `_Ready()` is called on any node.
