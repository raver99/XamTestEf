using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEF.Services.EF;
using Xamarin.Forms;

namespace TestEF
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        EntityFrameworkService service = new EntityFrameworkService();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            UpdateStatusLabel();
        }

        private void UpdateStatusLabel()
        {
            try
            {
                var all = service.GetAll();
                StatusLabel.Text = "Item count: " + all.Count;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                service.Insert(new ToDoEF.Models.TodoItem()
                {
                    Name = "test"
                });

                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
            }
        }
    }
}
