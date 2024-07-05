using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("generated")]
   public class TunedLengthModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      [SExprSubNode("type")]
      public GeneratedType Type { get; set; }

      [SExprSubNode("name")]
      public string Name { get; set; } = "";

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("corner_radius_percent")]
      public double CornerRadiusPerc { get; set; }

      [SExprSubNode("initial_side")]
      public string InitialSide { get; set; } = "";

      [SExprSubNode("last_diff_pair_gap")]
      public double LastDiffPairGap { get; set; }

      [SExprSubNode("last_netname")]
      public string LastNetName { get; set; } = "";

      [SExprSubNode("last_status")]
      public string LastStatus { get; set; } = "";

      [SExprSubNode("last_track_width")]
      public double LastTrackWidth { get; set; }

      [SExprSubNode("last_tuning")]
      public string LastTuning { get; set; } = "";

      [SExprSubNode("max_amplitude")]
      public double MaxAmplitude { get; set; }

      [SExprSubNode("min_amplitude")]
      public double MinAmplitude { get; set; }

      [SExprSubNode("min_spacing")]
      public double MinSpacing { get; set; }

      [SExprSubNode("override_custom_rules")]
      public bool OverrideCustomRules { get; set; }

      [SExprSubNode("rounded")]
      public bool Rounded { get; set; }

      [SExprSubNode("single_sided")]
      public bool SingleSided { get; set; }

      [SExprSubNode("target_length")]
      public double TargetLength { get; set; }

      [SExprSubNode("target_length_max")]
      public double TargetLengthMax { get; set; }

      [SExprSubNode("target_length_min")]
      public double TargetLengthMin { get; set; }

      [SExprSubNode("target_skew")]
      public double TargetSkew { get; set; }

      [SExprSubNode("target_skew_max")]
      public double TargetSkewMax { get; set; }

      [SExprSubNode("target_skew_min")]
      public double TargetSkewMin { get; set; }

      [SExprSubNode("tuning_mode")]
      public string TuningMode { get; set; } = "";

      [SExprNode("base_line/pts")]
      public CoordinateModel? BaseLine { get; set; }

      [SExprNode("base_line_coupled/pts")]
      public CoordinateModel? BaseLineCoupled { get; set; }

      public MemberCollection? Members { get; set; }

      [SExprNode("origin/xy")]
      public XyModel? Origin { get; set; }

      [SExprNode("end/xy")]
      public XyModel? End { get; set; }
      #endregion

      #region Constructors
      public TunedLengthModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(generated");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("type", Type));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("name", Name));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine("(base_line");
         BaseLine?.WriteNode(builder, indent + 2);
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("corner_radius_percent", CornerRadiusPerc));

         builder.Append('\t', indent + 1);
         builder.AppendLine("(end");
         End?.WriteNode(builder, indent + 2);
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("initial_side", InitialSide));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("last_diff_pair_gap", LastDiffPairGap));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("last_netname", LastNetName));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("last_status", LastStatus));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("last_track_width", LastTrackWidth));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("last_tuning", LastTuning));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("max_amplitude", MaxAmplitude));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("min_amplitude", MinAmplitude));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("min_spacing", MinSpacing));

         builder.Append('\t', indent + 1);
         builder.AppendLine("(origin");
         Origin?.WriteNode(builder, indent + 2);
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("override_custom_rules", OverrideCustomRules));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("rounded", Rounded));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("single_sided", SingleSided));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("target_length", TargetLength));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("target_length_max", TargetLengthMax));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("target_length_min", TargetLengthMin));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("target_skew", TargetSkew));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("target_skew_max", TargetSkewMax));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("target_skew_min", TargetSkewMin));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("tuning_mode", TuningMode));

         Members?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
