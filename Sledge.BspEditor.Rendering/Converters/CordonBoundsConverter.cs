using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Threading.Tasks;
using Sledge.BspEditor.Documents;
using Sledge.BspEditor.Primitives.MapData;
using Sledge.BspEditor.Primitives.MapObjects;
using Sledge.BspEditor.Rendering.Scene;
using Sledge.Rendering.Scenes.Renderables;

namespace Sledge.BspEditor.Rendering.Converters
{
    [Export(typeof(IMapObjectSceneConverter))]
    public class CordonBoundsConverter : IMapObjectSceneConverter
    {
        public MapObjectSceneConverterPriority Priority => MapObjectSceneConverterPriority.OverrideLow;

        private CordonBounds GetCordon(MapDocument doc)
        {
            return doc.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds {Enabled = false};
        }

        public bool ShouldStopProcessing(SceneMapObject smo, MapDocument document, IMapObject obj)
        {
            return false;
        }

        public bool Supports(IMapObject obj)
        {
            return obj is Root;
        }

        public Task<bool> Convert(SceneMapObject smo, MapDocument document, IMapObject obj)
        {
            var c = GetCordon(document);
            if (!c.Enabled) return Task.FromResult(true);

            foreach (var line in c.Box.GetBoxLines())
            {
                smo.SceneObjects.Add(new object(), new Line(Color.Red, line.Start.ToVector3(), line.End.ToVector3()));
            }

            return Task.FromResult(true);
        }

        public Task<bool> PropertiesChanged(SceneObjectsChangedEventArgs args, SceneMapObject smo, MapDocument document, IMapObject obj, HashSet<string> propertyNames)
        {
            return Task.FromResult(false);
        }
    }
}