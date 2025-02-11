using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
   /// <summary>
   /// List of all the <see cref="NetModel">Nets</see> in a <see cref="PcbModel">PCB.</see>
   /// </summary>
   [SExprListNode("net")]
   public class NetCollection : Model, IKiCadReadable, IKiCadWriteableCollection
   {
      #region Local Props
      private ObservableCollection<NetModel> _nets = [];
      #endregion

      #region Constructors
      /// <inheritdoc/>
      public NetCollection() { }
      #endregion

      #region Methods
      /// <inheritdoc/>
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

      //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      //{
      //   foreach (var net in Nets)
      //   {
      //      net.WriteNode(builder, indent);
      //   }
      //}

      /// <inheritdoc/>
      public void WriteCollection(StringBuilder builder, int indent)
      {
         foreach (var net in Nets)
         {
            KiCadWriteUtils2.WriteNode(net, builder, indent + 1);
         }
      }

      /// <inheritdoc/>
      public override string ToString() => $"Net Coll - {Nets.Count}";
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
