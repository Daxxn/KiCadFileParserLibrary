using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Collections;

/// <summary>
/// List of points.
/// </summary>
[SExprListNode("xy")]
public class PointCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<XyModel> _points = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PointCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var children = node.GetNodes("xy");
      if (children is null) return;
      Points = [];
      foreach (var child in children)
      {
         XyModel xy = new();
         xy.ParseNode(child);
         Points.Add(xy);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var point in Points)
      {
         KiCadWriteUtils.WriteNode(point, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of points.
   /// </summary>
   public ObservableCollection<XyModel> Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
