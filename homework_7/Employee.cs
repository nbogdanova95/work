using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    public class Employee: INotifyPropertyChanged
    {
        string empl_name,empl_surname;
        public int Id { get; set; }

        public string Name
        {
            get { return this.empl_name; }
            set {
                this.empl_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name))); }
        }

        public string SurName
        {
            get { return this.empl_surname; }
            set
            {
                this.empl_surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SurName)));
            }
        }

        public int Dep_Id_emp { get; set; }

        public Employee(int Id, string Name, string SurName, int Dep_Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.SurName = SurName;
            this.Dep_Id_emp = Dep_Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //public override string ToString()
        //{
        //    return $"{Id}\t{Name}\t{SurName}\t{Dep_Id_emp}";
        //}

    }
}
