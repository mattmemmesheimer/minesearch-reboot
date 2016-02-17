using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSearch.Common;
using MineSearch.Game;
using MineSearch.Wpf.Models;
using MineSearch.Wpf.ViewModels;

namespace MineSearch.Wpf.Test.ViewModelTests
{
    [TestClass]
    public class SettingsViewModelTest
    {
        [TestMethod]
        public void TestSave()
        {
            var viewModel = new SettingsViewModel(new DefaultGameSettings());
            viewModel.SaveCommand.Execute(null);
            Assert.IsTrue(viewModel.Saved);
        }

        [TestMethod]
        public void TestCancel()
        {
            var viewModel = new SettingsViewModel(new DefaultGameSettings());
            viewModel.CancelCommand.Execute(null);
            Assert.IsFalse(viewModel.Saved);
        }
    }
}
