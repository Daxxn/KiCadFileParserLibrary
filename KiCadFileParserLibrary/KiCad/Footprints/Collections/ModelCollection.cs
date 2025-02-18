using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections;

/// <summary>
/// List of <see cref="Footprint3DModel">3D Models.</see>
/// </summary>
[SExprListNode("model")]
public class ModelCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<Footprint3DModel> _models = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ModelCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var children = node.GetNodes("model");
      if (children is null) return;
      Models = [];
      foreach (var child in children)
      {
         Footprint3DModel fpm = new();
         fpm.ParseNode(child);
         Models.Add(fpm);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Models - {Models.Count}";
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var model in Models)
      {
         KiCadWriteUtils.WriteNode(model, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="Footprint3DModel">3D Models.</see>
   /// </summary>
   public ObservableCollection<Footprint3DModel> Models
   {
      get => _models;
      set
      {
         _models = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
