using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    public class Department: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string dep_name;
        public int Dep_id { get; set; }

        public string Dep_Name { get { return this.dep_name; }
            set {
                this.dep_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Dep_Name))); } }

        public Department(int Id, string Name)
        {
            
            Dep_id = Id;
            Dep_Name = Name;
        }

        //public override string ToString()
        //{
        //    return $"{Dep_id}\t{Dep_Name}";
        //}
    }
}
