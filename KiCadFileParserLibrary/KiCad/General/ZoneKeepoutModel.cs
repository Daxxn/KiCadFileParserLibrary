using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("keepout")]
   public class ZoneKeepoutModel : Model, IKiCadReadable
   {
      #region Local Props
      private KeepoutType _tracks;
      private KeepoutType _vias;
      private KeepoutType _pads;
      private KeepoutType _copper;
      private KeepoutType _footprints;
      #endregion

      #region Constructors
      public ZoneKeepoutModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(keepout");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("tracks", Tracks));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("vias", Vias));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("pads", Pads));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("copperpour", CopperPour));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("footprints", Footprints));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprSubNode("tracks")]
      public KeepoutType Tracks
      {
         get => _tracks;
         set
         {
            _tracks = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("vias")]
      public KeepoutType Vias
      {
         get => _vias;
         set
         {
            _vias = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("pads")]
      public KeepoutType Pads
      {
         get => _pads;
         set
         {
            _pads = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("copperpour")]
      public KeepoutType CopperPour
      {
         get => _copper;
         set
         {
            _copper = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("footprints")]
      public KeepoutType Footprints
      {
         get => _footprints;
         set
         {
            _footprints = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
