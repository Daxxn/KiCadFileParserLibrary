using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// List of net-tie groups.
/// </summary>
[SExprNode("net_tie_pad_groups")]
public class NetTieGroupModel : Model, IKiCadReadable
{
   #region Local Props
   private ObservableCollection<string>? _groups;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public NetTieGroupModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties is null) return;

      Groups = [];
      foreach (var group in node.Properties[1..])
      {
         Groups.Add(group);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Net-Ties - {Groups?.Count}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of net-tie groups.
   /// </summary>
   public ObservableCollection<string>? Groups
   {
      get => _groups;
      set
      {
         _groups = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
