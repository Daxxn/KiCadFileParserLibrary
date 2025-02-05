using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
    [SExprNode("zone")]
   public class ZoneModel : Model, IKiCadReadable
   {
      #region Local Props
      private int _net;
      private string _netName;
      private string? _layer;
      private LayerCollection? _layers;
      private string? _id;
      private string? _name;
      private HatchModel? _hatch;
      private int _priority;
      private ConnectPadsModel? _connectPads;
      private double? _minThickness;
      private bool _filledAreaThick;
      private ZoneFillSettingsModel? _fill;
      private ZoneKeepoutModel? _keepout;
      private PolygonModel? _polygon;
      private ZoneFillPolygonModel? _polygonFill;
      private ZoneFillSegments? _segments;
      private ZoneAttributesModel? _attributes;
      #endregion

      #region Constructors
      public ZoneModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(zone");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net", Net));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net_name", NetName));

         if (Layer != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));
         }
         else
         {
            Layers?.WriteNode(builder, indent + 1);
         }

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         if (Name != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("name", Name));
         }

         Hatch?.WriteNode(builder, indent + 1);

         if (Priority != 0)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("priority", Priority));
         }

         Attributes?.WriteNode(builder, indent + 1);

         ConnectPads?.WriteNode(builder, indent + 1);

         if (MinThickness != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("min_thickness", MinThickness));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("filled_areas_thickness", FilledAreasThickness));

         Keepout?.WriteNode(builder, indent + 1);

         Fill?.WriteNode(builder, indent + 1);

         Polygon?.WriteNode(builder, indent + 1);

         PolygonFill?.WriteNode(builder, indent + 1);

         Segments?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprSubNode("net")]
      public int Net
      {
         get => _net;
         set
         {
            _net = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("net_name")]
      public string NetName
      {
         get => _netName;
         set
         {
            _netName = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("layer")]
      public string? Layer
      {
         get => _layer;
         set
         {
            _layer = value;
            OnPropertyChanged();
         }
      }

      public LayerCollection? Layers
      {
         get => _layers;
         set
         {
            _layers = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string? ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("name")]
      public string? Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      public HatchModel? Hatch
      {
         get => _hatch;
         set
         {
            _hatch = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("priority")]
      public int Priority
      {
         get => _priority;
         set
         {
            _priority = value;
            OnPropertyChanged();
         }
      }

      public ConnectPadsModel? ConnectPads
      {
         get => _connectPads;
         set
         {
            _connectPads = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("min_thickness")]
      public double? MinThickness
      {
         get => _minThickness;
         set
         {
            _minThickness = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("filled_areas_thickness")]
      public bool FilledAreasThickness
      {
         get => _filledAreaThick;
         set
         {
            _filledAreaThick = value;
            OnPropertyChanged();
         }
      }

      public ZoneFillSettingsModel? Fill
      {
         get => _fill;
         set
         {
            _fill = value;
            OnPropertyChanged();
         }
      }

      public ZoneKeepoutModel? Keepout
      {
         get => _keepout;
         set
         {
            _keepout = value;
            OnPropertyChanged();
         }
      }

      public PolygonModel? Polygon
      {
         get => _polygon;
         set
         {
            _polygon = value;
            OnPropertyChanged();
         }
      }

      public ZoneFillPolygonModel? PolygonFill
      {
         get => _polygonFill;
         set
         {
            _polygonFill = value;
            OnPropertyChanged();
         }
      }

      public ZoneFillSegments? Segments
      {
         get => _segments;
         set
         {
            _segments = value;
            OnPropertyChanged();
         }
      }

      public ZoneAttributesModel? Attributes
      {
         get => _attributes;
         set
         {
            _attributes = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
