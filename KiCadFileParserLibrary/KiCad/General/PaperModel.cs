using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// Paper definition.
/// </summary>
[SExprNode("paper")]
public class PaperModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _name;
   private bool _isCustomSize;
   private double? _width;
   private double? _height;
   private bool _isPortrait;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PaperModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         if (node.Properties.Count > 1)
         {
            if (node.Properties[1] == "User")
            {
               IsCustomSize = true;
               var props = GetType().GetProperties();

               KiCadParseUtils.ParseProperties(props, node, this);
               KiCadParseUtils.ParseTokens(props, node, this);
            }
            else
            {
               var props = GetType().GetProperties();

               KiCadParseUtils.ParseProperties(props, node, this);
            }
         }
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      if (IsCustomSize)
      {
         return $"Paper - Name: {Name} - W: {Width} - H: {Height} - Portrait: {IsPortrait}";
      }
      else
      {
         return $"Paper - Name: {Name} - Portrait: {IsPortrait}";
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Paper type name.
   /// </summary>
   [SExprProperty(1)]
   public string? Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is a custom paper size.
   /// </summary>
   public bool IsCustomSize
   {
      get => _isCustomSize;
      set
      {
         _isCustomSize = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Custom paper horizontal width.
   /// </summary>
   [SExprProperty(2, true)]
   public double? Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Custom paper vertical height.
   /// </summary>
   [SExprProperty(1, true)]
   public double? Height
   {
      get => _height;
      set
      {
         _height = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Paper orientation.
   /// </summary>
   [SExprToken("portrait")]
   public bool IsPortrait
   {
      get => _isPortrait;
      set
      {
         _isPortrait = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
