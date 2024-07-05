using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad.Schematics
{
   public class ProjectSchematics : IList<Schematic>
   {
      #region Local Props
      private List<Schematic>? Schematics { get; set; }
      public int Count { get; }
      public bool IsReadOnly { get; }

      #endregion

      #region Constructors
      public ProjectSchematics() { }

      public int IndexOf(Schematic item)
      {
         return Schematics?.IndexOf(item) ?? -1;
      }

      public void Insert(int index, Schematic item)
      {
         throw new NotImplementedException();
      }

      public void RemoveAt(int index)
      {
         throw new NotImplementedException();
      }

      public void Add(Schematic item)
      {
         throw new NotImplementedException();
      }

      public void Clear()
      {
         throw new NotImplementedException();
      }

      public bool Contains(Schematic item)
      {
         throw new NotImplementedException();
      }

      public void CopyTo(Schematic[] array, int arrayIndex)
      {
         throw new NotImplementedException();
      }

      public bool Remove(Schematic item)
      {
         throw new NotImplementedException();
      }

      public IEnumerator<Schematic> GetEnumerator()
      {
         throw new NotImplementedException();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Methods
      #endregion

      #region Full Props
      public Schematic this[int index]
      {
         get
         {
            if (Schematics is null) throw new NullReferenceException("No schematics found. Unable to find schematic at index.");
            return Schematics[index];
         }
         set
         {
            Schematics![index] = value;
         }
      }

      #endregion
   }
}
