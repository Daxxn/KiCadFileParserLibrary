using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprListNode("property")]
   public class TextVariableCollection : Model, IKiCadReadable, IKiCadWriteableCollection
   {
      #region Local Props
      private ObservableCollection<GenericProperty>? _textVars;
      #endregion

      #region Constructors
      public TextVariableCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("property");
         if (children is null) return;
         TextVars = [];
         foreach (var child in children)
         {
            GenericProperty textVar = new();
            textVar.ParseNode(child);
            TextVars.Add(textVar);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         if (TextVars is null) return;
         foreach (var txtVar in TextVars)
         {
            //txtVar.WriteNode(builder, indent);
            KiCadWriteUtils2.WriteNode(txtVar, builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Properties - {TextVars?.Count}";
      }

      public void WriteCollection(StringBuilder builder, int indent)
      {
         if (TextVars is null) return;
         foreach (var txtVar in TextVars)
         {
            txtVar.WriteNode(builder, indent);
         }
      }
      #endregion

      #region Full Props
      public ObservableCollection<GenericProperty>? TextVars
      {
         get => _textVars;
         set
         {
            _textVars = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
