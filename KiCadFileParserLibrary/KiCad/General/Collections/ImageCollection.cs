using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Collections;

/// <summary>
/// List of <see cref="ImageModel">Images.</see>
/// </summary>
[SExprListNode("image")]
public class ImageCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<ImageModel>? _images;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ImageCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var children = node.GetNodes("image");
      if (children is null) return;
      Images = [];
      foreach (var child in children)
      {
         ImageModel image = new();
         image.ParseNode(child);
         Images.Add(image);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Images - {Images?.Count}";
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Images is null) return;
      foreach (var img in Images)
      {
         KiCadWriteUtils2.WriteNode(img, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="ImageModel">Images.</see>
   /// </summary>
   public ObservableCollection<ImageModel>? Images
   {
      get => _images;
      set
      {
         _images = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
