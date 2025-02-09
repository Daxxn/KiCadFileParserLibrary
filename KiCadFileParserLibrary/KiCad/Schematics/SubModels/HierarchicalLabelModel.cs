using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

[SExprNode("hierarchical_label")]
public class HierarchicalLabelModel : Model, IKiCadReadable
{
   #region Local Props
   private string _name = "";
   private LabelShape _shape = LabelShape.Input;
   private LocationModel _location = new();
   private EffectsModel _effects = new();
   private string _id = "";
   #endregion

   #region Constructors
   public HierarchicalLabelModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   #endregion

   #region Full Props
   [SExprProperty(1)]
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("shape")]
   public LabelShape Shape
   {
      get => _shape;
      set
      {
         _shape = value;
         OnPropertyChanged();
      }
   }

   public LocationModel Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   public EffectsModel Effects
   {
      get => _effects;
      set
      {
         _effects = value;
         OnPropertyChanged();
      }
   }

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
   #endregion
}
