using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFEidos.Models.Classes;
using WPFEidos.Models.Other;

namespace WPFEidos.Models
{
    internal class DepartmentWindowModel : BindableBase
    {
        public ObservableCollection<Room> AvailableRooms;
        public ObservableCollection<Room> CurrentRooms;

        public ObservableCollection<Employee> AvailableEmployees;
        public ObservableCollection<Employee> CurrentEmployees;

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        private Room selectedRoom;
        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set { SetProperty(ref selectedRoom, value); }
        }

        private Room newSelectedRoom;
        public Room NewSelectedRoom
        {
            get { return newSelectedRoom; }
            set { SetProperty(ref newSelectedRoom, value); }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { SetProperty(ref selectedEmployee, value); }
        }

        private Employee newSelectedEmployee;
        public Employee NewSelectedEmployee
        {
            get { return newSelectedEmployee; }
            set { SetProperty(ref newSelectedEmployee, value); }
        }

        private Department currentDepartment;
        public Department CurrentDepartment
        {
            get { return currentDepartment; }
            set { SetProperty(ref currentDepartment, value); }
        }

        #region Commands
        public ICommand AddRoomCommand { get; set; }
        public ICommand RemoveRoomCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }

        public ICommand SaveCommand { get; set; }
        #endregion

        public DepartmentWindowModel(Department department)
        {
            CurrentDepartment = department;
            AvailableRooms = DataHolder.Rooms.Where(x => x.DepartmentId == 0).ToObservableCollection();
            CurrentRooms = CurrentDepartment.Rooms.ToObservableCollection();
            AvailableEmployees = DataHolder.Employees.Where(x => x.DepartmentId == 0).ToObservableCollection();
            CurrentEmployees = CurrentDepartment.Employees.ToObservableCollection();

            // could be used directly to binding but I don't care :)
            Name = department.Name;
            Address = department.Address;

            AddRoomCommand = new DelegateCommand(OnAddRoomCommand);
            RemoveRoomCommand = new DelegateCommand(OnRemoveRoomCommand);
            AddEmployeeCommand = new DelegateCommand(OnAddEmployeeCommand);
            RemoveEmployeeCommand = new DelegateCommand(OnRemoveEmployeeCommand);

            SaveCommand = new DelegateCommand<object>(OnSaveCommand);
        }

        private void OnAddRoomCommand()
        {
            if (NewSelectedRoom != null)
            {
                CurrentRooms.Add(NewSelectedRoom);
                AvailableRooms.Remove(NewSelectedRoom);
                return;
            }
            MessageBox.Show("Select a new room");
        }

        private void OnRemoveRoomCommand()
        {
            if (SelectedRoom != null)
            {
                AvailableRooms.Add(SelectedRoom);
                CurrentRooms.Remove(SelectedRoom);
                return;
            }
            MessageBox.Show("Select a room to be removed");
        }

        private void OnAddEmployeeCommand()
        {
            if (NewSelectedEmployee != null)
            {
                CurrentEmployees.Add(NewSelectedEmployee);
                AvailableEmployees.Remove(NewSelectedEmployee);
                return;
            }
            MessageBox.Show("Select a new employee");
        }

        private void OnRemoveEmployeeCommand()
        {
            if (SelectedEmployee != null)
            {
                AvailableEmployees.Add(SelectedEmployee);
                CurrentEmployees.Remove(SelectedEmployee);
                return;
            }
            MessageBox.Show("Select an employee to be removed");
        }

        private void OnSaveCommand(object parameter)
        {
            var exists = DataHolder.Departments.Contains(CurrentDepartment);
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            if (string.IsNullOrEmpty(Address))
            {
                MessageBox.Show("Address cannot be empty");
                return;
            }
            CurrentDepartment.Name = Name;
            CurrentDepartment.Address = Address;

            // this all is done because of copying rooms. If I won't copy the rooms there won't be button Save. 
            // If there is no button Save - the app is a cringe
            foreach (var r in CurrentRooms)
            {
                r.DepartmentId = CurrentDepartment.Id;
            }
            foreach (var r in AvailableRooms)
            {
                r.DepartmentId = 0;
            }

            foreach (var e in CurrentEmployees)
            {
                e.DepartmentId = CurrentDepartment.Id;
            }
            foreach (var e in AvailableEmployees)
            {
                e.DepartmentId = 0;
            }

            if (!exists)
            {
                DataHolder.Departments.Add(CurrentDepartment);
            }
            CurrentDepartment.RaiseChanged();
            (parameter as Window).Close();
        }
    }
}
