using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics
{
   public class ProjectSchematics : Model
   {
      #region Local Props
      private ObservableCollection<Schematic>? _schematics;
      public int Count => _schematics?.Count ?? 0;
      public bool IsReadOnly => false;
      #endregion

      #region Constructors
      public ProjectSchematics() { }

      public int IndexOf(Schematic item)
      {
         return Schematics?.IndexOf(item) ?? -1;
      }

      public void Insert(int index, Schematic item)
      {
         Schematics?.Insert(index, item);
      }

      public void RemoveAt(int index)
      {
         Schematics?.RemoveAt(index);
      }

      public void Add(Schematic item)
      {
         Schematics?.Add(item);
      }

      public void Clear()
      {
         Schematics?.Clear();
      }

      public bool Contains(Schematic item)
      {
         return Schematics?.Contains(item) == true;
      }

      public void CopyTo(Schematic[] array, int arrayIndex)
      {
         Schematics?.CopyTo(array, arrayIndex);
      }

      public bool Remove(Schematic item)
      {
         return Schematics?.Remove(item) == true;
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

      public ObservableCollection<Schematic>? Schematics
      {
         get => _schematics;
         set
         {
            _schematics = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
