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
using MVVMLibrary;
using System.Security.Cryptography;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("generated")]
   public class TunedLengthModel : Model, IKiCadReadable
   {
      #region Local Props
      private string _id;
      private GeneratedType _type;
      private string _name;
      private string _layer;
      private double _cornerRadiusPerc;
      private string _initialSide;
      private double _lastDiffPairGap;
      private string _lastNetName;
      private string _lastStatus;
      private double _lastTrackWidth;
      private string _lastTuning;
      private double _maxAmp;
      private double _minAmp;
      private double _minSpaced;
      private bool _overrideCustomRules;
      private bool _rounded;
      private bool _singleSided;
      private double _targetLen;
      private double _targetLenMax;
      private double _targetLenMin;
      private double _targetSkew;
      private double _targetSkewMax;
      private double _targetSkewMin;
      private string _tuningMode;
      private CoordinateModel? _baseline;
      private CoordinateModel? _baselineCoupled;
      private MemberCollection? _members;
      private XyModel? _origin;
      private XyModel? _end;

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

         if (BaseLine != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine("(base_line");
            BaseLine?.WriteNode(builder, indent + 2);
            builder.Append('\t', indent + 1);
            builder.AppendLine(")");
         }

         if (BaseLineCoupled != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine("(base_line_coupled");
            BaseLineCoupled?.WriteNode(builder, indent + 2);
            builder.Append('\t', indent + 1);
            builder.AppendLine(")");
         }

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
      [SExprSubNode("uuid")]
      public string ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("type")]
      public GeneratedType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("name")]
      public string Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("layer")]
      public string Layer
      {
         get => _layer;
         set
         {
            _layer = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("corner_radius_percent")]
      public double CornerRadiusPerc
      {
         get => _cornerRadiusPerc;
         set
         {
            _cornerRadiusPerc = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("initial_side")]
      public string InitialSide
      {
         get => _initialSide;
         set
         {
            _initialSide = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("last_diff_pair_gap")]
      public double LastDiffPairGap
      {
         get => _lastDiffPairGap;
         set
         {
            _lastDiffPairGap = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("last_netname")]
      public string LastNetName
      {
         get => _lastNetName;
         set
         {
            _lastNetName = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("last_status")]
      public string LastStatus
      {
         get => _lastStatus;
         set
         {
            _lastStatus = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("last_track_width")]
      public double LastTrackWidth
      {
         get => _lastTrackWidth;
         set
         {
            _lastTrackWidth = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("last_tuning")]
      public string LastTuning
      {
         get => _lastTuning;
         set
         {
            _lastTuning = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("max_amplitude")]
      public double MaxAmplitude
      {
         get => _maxAmp;
         set
         {
            _maxAmp = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("min_amplitude")]
      public double MinAmplitude
      {
         get => _minAmp;
         set
         {
            _minAmp = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("min_spacing")]
      public double MinSpacing
      {
         get => _minSpaced;
         set
         {
            _minSpaced = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("override_custom_rules")]
      public bool OverrideCustomRules
      {
         get => _overrideCustomRules;
         set
         {
            _overrideCustomRules = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("rounded")]
      public bool Rounded
      {
         get => _rounded;
         set
         {
            _rounded = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("single_sided")]
      public bool SingleSided
      {
         get => _singleSided;
         set
         {
            _singleSided = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("target_length")]
      public double TargetLength
      {
         get => _targetLen;
         set
         {
            _targetLen = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("target_length_max")]
      public double TargetLengthMax
      {
         get => _targetLenMax;
         set
         {
            _targetLenMax = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("target_length_min")]
      public double TargetLengthMin
      {
         get => _targetLenMin;
         set
         {
            _targetLenMin = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("target_skew")]
      public double TargetSkew
      {
         get => _targetSkew;
         set
         {
            _targetSkew = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("target_skew_max")]
      public double TargetSkewMax
      {
         get => _targetSkewMax;
         set
         {
            _targetSkewMax = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("target_skew_min")]
      public double TargetSkewMin
      {
         get => _targetSkewMin;
         set
         {
            _targetSkewMin = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("tuning_mode")]
      public string TuningMode
      {
         get => _tuningMode;
         set
         {
            _tuningMode = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("base_line/pts")]
      public CoordinateModel? BaseLine
      {
         get => _baseline;
         set
         {
            _baseline = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("base_line_coupled/pts")]
      public CoordinateModel? BaseLineCoupled
      {
         get => _baselineCoupled;
         set
         {
            _baselineCoupled = value;
            OnPropertyChanged();
         }
      }

      public MemberCollection? Members
      {
         get => _members;
         set
         {
            _members = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("origin/xy")]
      public XyModel? Origin
      {
         get => _origin;
         set
         {
            _origin = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("end/xy")]
      public XyModel? End
      {
         get => _end;
         set
         {
            _end = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
