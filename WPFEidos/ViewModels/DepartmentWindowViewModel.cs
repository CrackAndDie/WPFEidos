using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using WPFEidos.Models;
using WPFEidos.Models.Classes;

namespace WPFEidos.ViewModels
{
    internal class DepartmentWindowViewModel : BindableBase
    {
        private DepartmentWindowModel model;

        public string Name
        {
            get { return model.Name; }
            set { model.Name = value; }
        }

        public string Address
        {
            get { return model.Address; }
            set { model.Address = value; }
        }

        public ObservableCollection<Room> AvailableRooms
        {
            get { return model.AvailableRooms; }
            set { model.AvailableRooms = value; }
        }

        public ObservableCollection<Room> CurrentRooms
        {
            get { return model.CurrentRooms; }
            set { model.CurrentRooms = value; }
        }

        public Room SelectedRoom
        {
            get { return model.SelectedRoom; }
            set { model.SelectedRoom = value; }
        }

        public Room NewSelectedRoom
        {
            get { return model.NewSelectedRoom; }
            set { model.NewSelectedRoom = value; }
        }

        public ObservableCollection<Employee> AvailableEmployees
        {
            get { return model.AvailableEmployees; }
            set { model.AvailableEmployees = value; }
        }

        public ObservableCollection<Employee> CurrentEmployees
        {
            get { return model.CurrentEmployees; }
            set { model.CurrentEmployees = value; }
        }

        public Employee SelectedEmployee
        {
            get { return model.SelectedEmployee; }
            set { model.SelectedEmployee = value; }
        }

        public Employee NewSelectedEmployee
        {
            get { return model.NewSelectedEmployee; }
            set { model.NewSelectedEmployee = value; }
        }

        #region Commands
        public ICommand AddRoomCommand => model.AddRoomCommand;
        public ICommand RemoveRoomCommand => model.RemoveRoomCommand;
        public ICommand AddEmployeeCommand => model.AddEmployeeCommand;
        public ICommand RemoveEmployeeCommand => model.RemoveEmployeeCommand;

        public ICommand SaveCommand => model.SaveCommand;
        #endregion

        public DepartmentWindowViewModel(Department department)
        {
            model = new DepartmentWindowModel(department);
            model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
        }
    }
}
