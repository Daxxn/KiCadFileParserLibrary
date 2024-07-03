using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Pcb.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("generated")]
   public class TunedLengthModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("type")]
      public GeneratedType Type { get; set; }

      [SExprSubNode("name")]
      public string? Name { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("corner_radius_percent")]
      public double CornerRadiusPerc { get; set; }

      [SExprSubNode("initial_side")]
      public string? InitialSide { get; set; }

      [SExprSubNode("last_diff_pair_gap")]
      public double LastDiffPairGap { get; set; }

      [SExprSubNode("last_netname")]
      public string? LastNetName { get; set; }

      [SExprSubNode("last_status")]
      public string? LastStatus { get; set; }

      [SExprSubNode("last_track_width")]
      public double LastTrackWidth { get; set; }

      [SExprSubNode("last_tuning")]
      public string? LastTuning { get; set; }

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
      public string? TuningMode { get; set; }

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
      #endregion

      #region Full Props

      #endregion
   }
}
