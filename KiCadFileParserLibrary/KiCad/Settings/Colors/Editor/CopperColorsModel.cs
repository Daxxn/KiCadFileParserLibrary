using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Utils.JsonConverters;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

/// <summary>
/// 
/// </summary>
public class CopperColorsModel : Model
{
   #region Local Props
   private RgbaColorModel _bottom = new();
   private RgbaColorModel _top = new();
   private RgbaColorModel _in1 = new();
   private RgbaColorModel _in2 = new();
   private RgbaColorModel _in3 = new();
   private RgbaColorModel _in4 = new();
   private RgbaColorModel _in5 = new();
   private RgbaColorModel _in6 = new();
   private RgbaColorModel _in7 = new();
   private RgbaColorModel _in8 = new();
   private RgbaColorModel _in9 = new();
   private RgbaColorModel _in10 = new();
   private RgbaColorModel _in11 = new();
   private RgbaColorModel _in12 = new();
   private RgbaColorModel _in13 = new();
   private RgbaColorModel _in14 = new();
   private RgbaColorModel _in15 = new();
   private RgbaColorModel _in16 = new();
   private RgbaColorModel _in17 = new();
   private RgbaColorModel _in18 = new();
   private RgbaColorModel _in19 = new();
   private RgbaColorModel _in20 = new();
   private RgbaColorModel _in21 = new();
   private RgbaColorModel _in22 = new();
   private RgbaColorModel _in23 = new();
   private RgbaColorModel _in24 = new();
   private RgbaColorModel _in25 = new();
   private RgbaColorModel _in26 = new();
   private RgbaColorModel _in27 = new();
   private RgbaColorModel _in28 = new();
   private RgbaColorModel _in29 = new();
   private RgbaColorModel _in30 = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CopperColorsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("b")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Bottom
   {
      get => _bottom;
      set
      {
         _bottom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("f")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Top
   {
      get => _top;
      set
      {
         _top = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in1")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In1
   {
      get => _in1;
      set
      {
         _in1 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in2")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In2
   {
      get => _in2;
      set
      {
         _in2 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in3")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In3
   {
      get => _in3;
      set
      {
         _in3 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in4")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In4
   {
      get => _in4;
      set
      {
         _in4 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in5")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In5
   {
      get => _in5;
      set
      {
         _in5 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in6")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In6
   {
      get => _in6;
      set
      {
         _in6 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in7")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In7
   {
      get => _in7;
      set
      {
         _in7 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in8")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In8
   {
      get => _in8;
      set
      {
         _in8 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in9")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In9
   {
      get => _in9;
      set
      {
         _in9 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in10")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In10
   {
      get => _in10;
      set
      {
         _in10 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in11")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In11
   {
      get => _in11;
      set
      {
         _in11 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in12")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In12
   {
      get => _in12;
      set
      {
         _in12 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in13")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In13
   {
      get => _in13;
      set
      {
         _in13 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in14")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In14
   {
      get => _in14;
      set
      {
         _in14 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in15")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In15
   {
      get => _in15;
      set
      {
         _in15 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in16")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In16
   {
      get => _in16;
      set
      {
         _in16 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in17")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In17
   {
      get => _in17;
      set
      {
         _in17 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in18")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In18
   {
      get => _in18;
      set
      {
         _in18 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in19")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In19
   {
      get => _in19;
      set
      {
         _in19 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in20")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In20
   {
      get => _in20;
      set
      {
         _in20 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in21")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In21
   {
      get => _in21;
      set
      {
         _in21 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in22")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In22
   {
      get => _in22;
      set
      {
         _in22 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in23")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In23
   {
      get => _in23;
      set
      {
         _in23 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in24")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In24
   {
      get => _in24;
      set
      {
         _in24 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in25")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In25
   {
      get => _in25;
      set
      {
         _in25 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in26")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In26
   {
      get => _in26;
      set
      {
         _in26 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in27")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In27
   {
      get => _in27;
      set
      {
         _in27 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in28")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In28
   {
      get => _in28;
      set
      {
         _in28 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in29")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In29
   {
      get => _in29;
      set
      {
         _in29 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty("in30")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel In30
   {
      get => _in30;
      set
      {
         _in30 = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
