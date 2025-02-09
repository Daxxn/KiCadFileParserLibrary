using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

[SExprListNode("no_connect")]
public class NoConnectCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<NoConnectModel> _ncs = new();
   #endregion

   #region Constructors
   public NoConnectCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var ncNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (ncNodes is null) return;
      NCs = [];
      foreach (var ncNode in ncNodes)
      {
         var nc = new NoConnectModel();
         nc.ParseNode(ncNode);
         NCs.Add(nc);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (NCs is null) return;
      foreach (var nc in NCs)
      {
         KiCadWriteUtils2.WriteNode(nc, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<NoConnectModel> NCs
   {
      get => _ncs;
      set
      {
         _ncs = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
