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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprListNode("net")]
   public class NetCollection : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<NetModel> _nets = [];
      #endregion

      #region Constructors
      public NetCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("net");
         if (children is null) return;
         Nets = [];
         foreach (var child in children)
         {
            NetModel newNet = new();
            newNet.ParseNode(child);
            Nets.Add(newNet);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var net in Nets)
         {
            net.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Nets - {Nets.Count}";
      }
      #endregion

      #region Full Props
      public ObservableCollection<NetModel> Nets
      {
         get => _nets;
         set
         {
            _nets = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
