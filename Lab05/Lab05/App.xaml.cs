using AutoMapper;
using Lab05.Automapper;
using Lab05.Model;
using Lab05.ViewModel;
using System.Windows;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DataModel _model;
        private DataViewModel _viewModel;

        public App()
        {
            _model = DataModel.Load();

            new Mapping().Create();
            _viewModel = Mapper.Map<DataModel, DataViewModel>(_model);

            var window = new MainWindow() { DataContext = _viewModel };
            window.Show();
        }

        protected override void OnExit(ExitEventArgs args)
        {
            try
            {
                _model = Mapper.Map<DataViewModel, DataModel>(_viewModel);
                _model.Save();
            }
            catch
            {
                base.OnExit(null);
            }
        }
    }
}
