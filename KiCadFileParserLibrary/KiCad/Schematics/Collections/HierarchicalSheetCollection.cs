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

[SExprListNode("sheet")]
public class HierarchicalSheetCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<HierarchicalSheetModel> _sheets = [];
   #endregion

   #region Constructors
   public HierarchicalSheetCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var sheetNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (sheetNodes is null) return;
      Sheets = [];
      foreach (var symNode in sheetNodes)
      {
         var sheet = new HierarchicalSheetModel();
         sheet.ParseNode(symNode);
         Sheets.Add(sheet);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Sheets is null) return;
      foreach (var sheet in Sheets)
      {
         KiCadWriteUtils2.WriteNode(sheet, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<HierarchicalSheetModel> Sheets
   {
      get => _sheets;
      set
      {
         _sheets = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
