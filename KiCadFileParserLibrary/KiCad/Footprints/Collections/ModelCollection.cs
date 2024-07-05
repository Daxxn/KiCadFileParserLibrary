using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("model")]
   public class ModelCollection : IKiCadReadable
   {
      #region Local Props
      public List<Footprint3DModel> Models { get; set; } = [];
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
      #endregion

      #region Full Props

      #endregion
   }
}
