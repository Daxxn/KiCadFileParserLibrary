﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprListNode("arc|segment|via")]
   public class TraceCollection : IKiCadReadable
   {
      #region Local Props
      public List<TraceArcModel>? Arcs { get; set; }
      public List<TraceSegmentModel>? Segments { get; set; }
      public List<ViaModel>? Vias { get; set; }
      #endregion

      #region Constructors
      public TraceCollection() { }
      #endregion

      #region Methods
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         if (Segments != null)
         {
            foreach (var segment in Segments)
            {
               segment.WriteNode(builder, indent);
            }
         }
         if (Vias != null)
         {
            foreach (var via in Vias)
            {
               via.WriteNode(builder, indent);
            }
         }
         if (Arcs != null)
         {
            foreach (var arcs in Arcs)
            {
               arcs.WriteNode(builder, indent);
            }
         }
      }

      public override string ToString()
      {
         return $"Traces - Arks: {Arcs?.Count} - Segments: {Segments?.Count} - Vias: {Vias?.Count}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
