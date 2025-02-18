using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections;

/// <summary>
/// List of all the Traces in the <see cref="PcbModel">PCB.</see>
/// <para/>
/// Including <see cref="TraceArcModel">Arcs,</see> <see cref="TraceSegmentModel">Segments,</see> and <see cref="ViaModel">Vias.</see>
/// </summary>
[SExprListNode("arc|segment|via")]
public class TraceCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<TraceArcModel>? _arcs;
   private ObservableCollection<TraceSegmentModel>? _segments;
   private ObservableCollection<ViaModel>? _vias;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TraceCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var arcNodes = node.GetNodes("arc");
      if (arcNodes != null)
      {
         Arcs = [];
         foreach (var arcNode in arcNodes)
         {
            TraceArcModel arc = new();
            arc.ParseNode(arcNode);
            Arcs.Add(arc);
         }
      }

      var segNodes = node.GetNodes("segment");
      if (segNodes != null)
      {
         Segments = [];
         foreach (var segNode in segNodes)
         {
            TraceSegmentModel seg = new();
            seg.ParseNode(segNode);
            Segments.Add(seg);
         }
      }

      var viaNodes = node.GetNodes("via");
      if (viaNodes != null)
      {
         Vias = [];
         foreach (var viaNode in viaNodes)
         {
            ViaModel via = new();
            via.ParseNode(viaNode);
            Vias.Add(via);
         }
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Segments != null)
      {
         foreach (var segment in Segments)
         {
            KiCadWriteUtils.WriteNode(segment, builder, indent);
         }
      }
      if (Vias != null)
      {
         foreach (var via in Vias)
         {
            KiCadWriteUtils.WriteNode(via, builder, indent);
         }
      }
      if (Arcs != null)
      {
         foreach (var arc in Arcs)
         {
            KiCadWriteUtils.WriteNode(arc, builder, indent);
         }
      }
   }

   /// <inheritdoc/>
   public override string ToString() => $"Traces - Arks: {Arcs?.Count} - Segments: {Segments?.Count} - Vias: {Vias?.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// List of all the <see cref="TraceArcModel">Arcs</see> in the <see cref="PcbModel">PCB.</see>
   /// </summary>
   public ObservableCollection<TraceArcModel>? Arcs
   {
      get => _arcs;
      set
      {
         _arcs = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of all the <see cref="TraceSegmentModel">Segments</see> in a <see cref="PcbModel">PCB.</see>
   /// </summary>
   public ObservableCollection<TraceSegmentModel>? Segments
   {
      get => _segments;
      set
      {
         _segments = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of all the <see cref="ViaModel">Vias</see> in a <see cref="PcbModel">PCB.</see>
   /// </summary>
   public ObservableCollection<ViaModel>? Vias
   {
      get => _vias;
      set
      {
         _vias = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Total <see cref="TraceArcModel">Arcs</see>, <see cref="TraceSegmentModel">Segments</see>, and <see cref="ViaModel">Vias</see>
   /// </summary>
   public int Total => Arcs?.Count ?? 0 + Segments?.Count ?? 0 + Vias?.Count ?? 0;
   #endregion
}
