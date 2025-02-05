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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("model")]
   public class ModelCollection : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<Footprint3DModel> _models = [];
      #endregion

      #region Constructors
      public ModelCollection() { }
      #endregion

      #region Methods
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var model in Models)
         {
            model.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Models - {Models.Count}";
      }
      #endregion

      #region Full Props
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
}
