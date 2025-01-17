﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module05exercise01.Services;
using Module05exercise01.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using System.Collections.ObjectModel;


namespace Module05exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    { 
    private readonly EmployeeService _employeeService;

    public ObservableCollection<Employee> EmployeeList { get; set; }

    private bool _isBusy;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged();
        }
    }

    private string _statusMessage;
    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoadDataCommand { get; }

    //Personal ViewModel Constructor

    public EmployeeViewModel()
    {
        _employeeService = new EmployeeService();
        EmployeeList = new ObservableCollection<Employee>();
        LoadDataCommand = new Command(async () => await LoadData());
        LoadData();
    }

    public async Task LoadData()
    {
        if (IsBusy) return;
        IsBusy = true;
        StatusMessage = "Load Employee Data...";
        try
        {
            var employees = await _employeeService.GetAllEmployeeAsync();
            EmployeeList.Clear();
            foreach (var employee in employees)
            {
                EmployeeList.Add(employee);
            }
            StatusMessage = "Data Loaded successfully";
        }
        catch (Exception ex)
        {
            StatusMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }

    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
