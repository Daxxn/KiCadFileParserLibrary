using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels;

/// <summary>
/// Sub-Symbol model
/// </summary>
[SExprNode("symbol")]
public class SubSymbolModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _name;
   private int _version;
   private SymbolStyleIdentifier _styleID;
   private PinCollection? _pins;
   private SyGraphicsCollection? _graphics;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SubSymbolModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseListNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Name
   /// </summary>
   [SExprProperty(1)]
   public string? Name
   {
      get => _name;
      set
      {
         _name = value;
         if (value != null)
         {
            if (value?.Length > 4 && value?.Contains('_') == true)
            {
               if (int.TryParse($"{value[^3]}", out int unit))
               {
                  Unit = unit;
               }
               if (int.TryParse($"{value[^1]}", out int styleId))
               {
                  StyleID = (SymbolStyleIdentifier)styleId;
               }
            }
         }
      }
   }

   /// <summary>
   /// Unit
   /// </summary>
   public int Unit
   {
      get => _version;
      set
      {
         _version = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Style identifier
   /// </summary>
   public SymbolStyleIdentifier StyleID
   {
      get => _styleID;
      set
      {
         _styleID = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of pins
   /// </summary>
   public PinCollection? Pins
   {
      get => _pins;
      set
      {
         _pins = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of graphics
   /// </summary>
   public SyGraphicsCollection? Graphics
   {
      get => _graphics;
      set
      {
         _graphics = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
