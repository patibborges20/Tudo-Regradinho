using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Tudo_Regradinho.Resources;

namespace Tudo_Regradinho
{
    public partial class MainPage : PhoneApplicationPage
    {
        clsRegras regrass;
        public clsRegras Regrinhas { get; set; }
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            AtualizarLista();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public void OnClickNovo(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/cadastrar.xaml", UriKind.Relative));
        }


        public void OnSelectionChange(object sender, SelectionChangedEventArgs e)
        {
           regrass= (sender as ListBox).SelectedItem as clsRegras;
        }

        public void OnClickAtualizar(object sender, EventArgs e)
        {
            AtualizarLista();

        }

        public void AtualizarLista()
        {

            List<clsRegras> lista = RegrasDB.GetRegras(string.Empty);
            lstRegras.ItemsSource = lista;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            AtualizarLista();
        }

        public void OnClickDeletar(object sender, EventArgs e)
        {
            if (regrass != null)
            {
                if (MessageBox.Show("Deletar " + regrass.Descricao + "?", " Atencao", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    RegrasDB.Deletar(regrass);
                    AtualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Regrinha para deletar");
            }


        }

        public void OnClickEditar(object sender, EventArgs e)
        {
            if (regrass== null)
            {
                MessageBox.Show("Selecione uma Regrinha para Editar");
            }
            else
            {
                NavigationService.Navigate(new Uri("/editar.xaml", UriKind.Relative));
            }

        }

     //   protected override void OnNavigatedFrom(NavigationEventArgs e)
     //   {
      //      base.OnNavigatedFrom(Editar);
//
      //      Editar page = e.Content as Editar;
      //      if (page != null)
      //      {
      //          page.Regrinhas = regrass;
           }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
      
