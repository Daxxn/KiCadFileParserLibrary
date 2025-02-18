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

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// <see cref="ZoneModel">Zone</see> keepout model.
/// </summary>
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
   /// <inheritdoc/>
   public ZoneKeepoutModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Keepout tracks.
   /// </summary>
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

   /// <summary>
   /// Keepout vias.
   /// </summary>
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

   /// <summary>
   /// Keepout pads.
   /// </summary>
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

   /// <summary>
   /// Keepout copper pours.
   /// </summary>
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

   /// <summary>
   /// Keepout footprints.
   /// </summary>
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
